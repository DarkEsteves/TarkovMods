using EFT.Hideout;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HideoutCat.Patches;

public class SelectAreaPatch : ModulePatch
{
    private static readonly Dictionary<AreaData, Action> UnsubscribeActions = new();

    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(AreaScreenSubstrate), nameof(AreaScreenSubstrate.SelectArea));
    }

    [PatchPostfix]
    private static void Postfix(AreaData areaData)
    {
        if (!UnsubscribeActions.ContainsKey(areaData))
        {
            UnsubscribeActions[areaData] = areaData.LevelUpdated.Subscribe(_ =>
            {
                var area = FindHideoutArea(areaData);
                if (area != null) BepInExPlayerEvents.Instance.TriggerAreaLevelUpdated(area);
            });
        }

        var hideoutArea = FindHideoutArea(areaData);
        if (hideoutArea != null)
        {
            BepInExPlayerEvents.Instance.TriggerAreaSelected(hideoutArea);
        }
    }

    internal static HideoutArea FindHideoutArea(AreaData areaData)
    {
        try
        {
            var areas = Comfort.Common.Singleton<HideoutController>.Instance.Areas;
            foreach (var kv in areas)
            {
                if (kv.Value.AreaTemplate.Type == areaData.Template.Type) return kv.Value;
            }
        }
        catch (Exception) { }
        return null;
    }
}
