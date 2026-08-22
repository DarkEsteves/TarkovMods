using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Comfort.Common;
using EFT;
using EFT.Hideout;
using AssetBundleLoader;
using HideoutCat.CatData;
using HideoutCat.Patches;
using HideoutCat.Pathfinding;
using HideoutCat.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.UnityConverters.Math;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HideoutCat;

[BepInPlugin("com.tarkin.hideoutcat", "Hideout Cat", "1.1.2")]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log;
    internal static ConfigEntry<ECatCoat> Coat;
    internal static ConfigEntry<Color> EyeColor;
    internal static ConfigEntry<float> MeowVolume;
    internal static ConfigEntry<float> StepVolume;
    internal static ConfigEntry<bool> StepsEnabled;
    internal static ConfigEntry<float> MeowFrequency;
    internal static ConfigEntry<float> ProximityMeowDistance;
    internal static ConfigEntry<float> WalkSpeed;
    internal static ConfigEntry<float> IdleWanderChance;
    internal static ConfigEntry<bool> CatEnabled;
    public static Graph CatGraph { get; private set; }

    public static int GetAreaLevel(HideoutArea area)
    {
        // Stage index: 0 = not built, 1..3 = built levels (same semantics as AreaData.CurrentLevel)
        if (area == null || area.AreaLevels == null) return 0;
        var idx = Array.IndexOf(area.AreaLevels, area.CurrentLevel);
        return idx < 0 ? 0 : idx;
    }

    private static bool _catSpawned;

    private void Start()
    {
        Log = Logger;
        InitConfiguration();

        var graph = LoadCatAreaData();
        if (graph == null)
        {
            Log.LogError("Error loading Cat graph data!!!");
            return;
        }

        CatGraph = graph;
        CatDependencyProviders.Initialize(graph, new BepInExPlayerEvents());

        new HideoutAwakePatch().Enable();
        new SelectAreaPatch().Enable();
        new GetAvailableHideoutActionsPatch().Enable();
        new PrepareWorkoutPatch().Enable();
        new StopWorkoutPatch().Enable();
        new BonusPanelPatch().Enable();

        HideoutAwakePatch.OnHideoutAwake += () =>
        {
            Log.LogInfo("[HideoutCat] HideoutAwake fired!");
            _catSpawned = false;
            SpawnCat();
        };
        BepInExPlayerEvents.Instance.AreaLevelUpdated += _ => SpawnCat();

        PropManager.Init();
    }

    private void InitConfiguration()
    {
        Coat = Config.Bind("Cat", "Coat", ECatCoat.Grey,
            new ConfigDescription("Cat coat texture. Applies on the next hideout load"));
        EyeColor = Config.Bind("Cat", "Eye Colour", new Color(0.56f, 0.75f, 0.4f),
            new ConfigDescription("Eye tint (multiplies the eye texture). Applies on the next hideout load"));

        MeowVolume = Config.Bind("Audio", "Meow Volume", 1f,
            new ConfigDescription("Volume of meows and purrs", new AcceptableValueRange<float>(0f, 1f)));
        StepVolume = Config.Bind("Audio", "Step Volume", 1f,
            new ConfigDescription("Volume of footsteps", new AcceptableValueRange<float>(0f, 1f)));
        StepsEnabled = Config.Bind("Audio", "Footsteps Enabled", true,
            new ConfigDescription("Play footstep sounds while the cat walks"));

        MeowFrequency = Config.Bind("Behavior", "Meow Frequency", 65f,
            new ConfigDescription("Average seconds between random meows (lower = more talkative)", new AcceptableValueRange<float>(10f, 300f)));
        ProximityMeowDistance = Config.Bind("Behavior", "Proximity Meow Distance", 5f,
            new ConfigDescription("Distance at which the cat notices you and may meow when looking at it", new AcceptableValueRange<float>(1f, 20f)));

        WalkSpeed = Config.Bind("Movement", "Walk Speed Multiplier", 1f,
            new ConfigDescription("Scales how fast the cat moves between waypoints", new AcceptableValueRange<float>(0.5f, 3f)));
        IdleWanderChance = Config.Bind("Movement", "Wander Frequency", 10f,
            new ConfigDescription("Average seconds idle before deciding to move to another area (lower = more active)", new AcceptableValueRange<float>(5f, 120f)));

        CatEnabled = Config.Bind("Spawning", "Enable Cat", true,
            new ConfigDescription("Toggle the cat. OFF removes him instantly; ON spawns him if requirements are met (no re-entry needed)"));
        CatEnabled.SettingChanged += (_, _) => ToggleCat();

        // Live reload: changing coat/eyes in F12 re-applies instantly if the cat exists
        Coat.SettingChanged += (_, _) => ApplyCosmeticsToExistingCat();
        EyeColor.SettingChanged += (_, _) => ApplyCosmeticsToExistingCat();
    }

    private static void ToggleCat()
    {
        try
        {
            if (CatEnabled!.Value)
            {
                _catSpawned = false;
                SpawnCat();
            }
            else
            {
                var cat = GameObject.Find("hideoutcat(Clone)") ?? GameObject.Find("hideoutcat");
                if (cat)
                {
                    UnityEngine.Object.Destroy(cat);
                    Log.LogInfo("[HideoutCat] Cat removed (disabled in config)");
                }
                _catSpawned = false;
            }
        }
        catch (Exception ex)
        {
            Log.LogError($"[HideoutCat] Toggle failed: {ex}");
        }
    }

    private static void ApplyCosmeticsToExistingCat()
    {
        var catObj = GameObject.Find("hideoutcat(Clone)") ?? GameObject.Find("hideoutcat");
        if (!catObj)
        {
            Log.LogInfo("[HideoutCat] Cat not in scene; cosmetics will apply on next spawn");
            return;
        }

        var renderer = catObj.GetComponentInChildren<SkinnedMeshRenderer>();
        if (!renderer) return;

        renderer.materials[1].color = EyeColor!.Value;

        var texName = "MAINTEX_" + Coat!.Value.ToString().ToUpper();
        var bundle = BundleLoader.LoadAssetBundle("hideoutcat");
        var coatTex = bundle ? bundle?.LoadAsset<Texture2D>(texName) : null;
        if (coatTex)
        {
            renderer.materials[0].mainTexture = coatTex;
            Log.LogInfo($"[HideoutCat] Applied coat {Coat.Value} + eye color live");
        }
        else
        {
            Log.LogError($"[HideoutCat] Error loading {Coat.Value} coat texture");
        }
    }

    private static Graph LoadCatAreaData()
    {
        try
        {
            var path = Path.Combine(
                Path.GetDirectoryName(Application.dataPath),
                "BepInEx", "plugins", "tarkin-HideoutCat", "bundles", "CatNodeGraph.json");

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new Vector3Converter());

            var nodes = JsonConvert.DeserializeObject<List<Node>>(File.ReadAllText(path));
            if (nodes == null) throw new NullReferenceException();

            foreach (var node in nodes)
            {
                foreach (var connectedName in node.connectedToNamesForSerialization!)
                {
                    var target = nodes.Find(n => n.name == connectedName);
                    if (target != null) node.connectedTo.Add(target);
                    else Log.LogWarning($"Node '{node.name}': connected '{connectedName}' not found");
                }
                node.connectedToNamesForSerialization = null;
            }

            return new Graph(nodes);
        }
        catch (Exception ex)
        {
            Log.LogError("error loading cat config file: " + ex);
            return null;
        }
    }

    private static bool RequirementsMet()
    {
        var areas = Patches.HideoutAwakePatch.GetAreas();
        if (areas == null)
        {
            Log.LogWarning("[HideoutCat] Areas dictionary not available (controller null)");
            return false;
        }

        HideoutArea areaKitchen = null;
        HideoutArea areaHeating = null;
        foreach (var kv in areas)
        {
            if (kv.Value.AreaTemplate.Type == EAreaType.Kitchen) { areaKitchen = kv.Value; }
            else if (kv.Value.AreaTemplate.Type == EAreaType.Heating) { areaHeating = kv.Value; }

            if (areaKitchen != null && areaHeating != null) break;
        }

        if (areaKitchen == null)
        {
            Log.LogWarning("[HideoutCat] Kitchen area NOT FOUND in Areas dictionary!");
            foreach (var kv in areas)
            {
                Log.LogWarning($"[HideoutCat]   area: {kv.Key} -> {kv.Value?.AreaTemplate?.Name}");
            }
            return false;
        }

        var kitchenLvl = GetAreaLevel(areaKitchen);
        var heatingLvl = areaHeating != null ? GetAreaLevel(areaHeating) : 0;
        Log.LogInfo($"[HideoutCat] Kitchen level={kitchenLvl}, Heating level={heatingLvl}");

        // Cat requires: Nutrition Unit level 1+ AND Heating level 1+
        return kitchenLvl >= 1 && heatingLvl >= 1;
    }

    private static void SpawnCat()
    {
        if (_catSpawned || !RequirementsMet()) return;
        _catSpawned = true;

        var bundle = BundleLoader.LoadAssetBundle("hideoutcat");
        var prefab = bundle?.LoadAsset<GameObject>("hideoutcat");
        var catObj = Instantiate(prefab);
        if (!catObj) throw new NullReferenceException();

        BundleLoader.ReplaceShadersToNative(catObj);

        var renderer = catObj.GetComponentInChildren<SkinnedMeshRenderer>();
        renderer.materials[1].color = EyeColor!.Value;

        if (Coat!.Value != ECatCoat.Grey)
        {
            var texName = "MAINTEX_" + Coat.Value.ToString().ToUpper();
            var coatTex = bundle?.LoadAsset<Texture2D>(texName);
            if (coatTex) renderer.materials[0].mainTexture = coatTex;
            else Log.LogError($"Error loading {Coat.Value} coat texture");
        }

        var cat = catObj.AddComponent<Cat>();

        // Pick a random dead-end node matching an unlocked area (original 4.1 spawn logic)
        var areas = Patches.HideoutAwakePatch.GetAreas();
        var availableAreas = new List<HideoutArea>();
        foreach (var kv in areas)
        {
            if (GetAreaLevel(kv.Value) > 0) availableAreas.Add(kv.Value);
        }

        if (availableAreas.Count > 0)
        {
            Log.LogInfo($"{availableAreas.Count} avaiable areas");
            Random.InitState((int)DateTime.Now.Ticks);
            for (var i = availableAreas.Count - 1; i > 0; i--)
            {
                var j = Random.Range(0, i + 1);
                (availableAreas[i], availableAreas[j]) = (availableAreas[j], availableAreas[i]);
            }

            foreach (var area in availableAreas)
            {
                var deadEnds = CatGraph.FindDeadEndNodesByAreaTypeAndLevel(
                    area.AreaTemplate.Type,
                    GetAreaLevel(area)
                );
                if (deadEnds.Count <= 0) continue;

                var chosen = deadEnds[Random.Range(0, deadEnds.Count)];
                cat.transform.position = CatGraph.GetNodeClosestWaypoint(chosen.position).position;
                cat.SetTargetNode(chosen);
                Log.LogInfo("Cat spawned into scene!");
                return;
            }
        }

        Log.LogInfo("No available areas, defaulting to a random waypoint node");
        var fallback = CatGraph.GetNodeClosestWaypoint(new Vector3(Random.value * 16f, 0f, 0f));
        cat.transform.position = fallback.position;
        cat.SetTargetNode(fallback);
        Log.LogInfo("Cat spawned into scene!");
    }
}
