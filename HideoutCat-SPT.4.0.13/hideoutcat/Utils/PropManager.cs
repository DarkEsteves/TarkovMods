using AssetBundleLoader;
using Comfort.Common;
using EFT;
using EFT.Hideout;
using HideoutCat;
using HideoutCat.Patches;
using UnityEngine;

namespace HideoutCat.Utils;

public static class PropManager
{
    private static GameObject? _herring;

    public static void Init()
    {
        HideoutAwakePatch.OnHideoutAwake += UpdateProps;

        BepInExPlayerEvents.Instance.AreaLevelUpdated += _ =>
        {
            UpdateProps();
        };
    }

    private static void UpdateProps()
    {
        HideUnwantedSceneObjects();
        LoadProps();
    }

    private static void LoadProps()
    {
        var areas = Patches.HideoutAwakePatch.GetAreas();
        if (areas == null) { return; }

        HideoutArea? area = null;
        foreach (var x in areas)
        {
            if (x.Value.AreaTemplate.Type != EAreaType.Kitchen) { continue; }

            area = x.Value;
            break;
        }

        if (area == null) { return; }

        if (!_herring)
        {
            var bundle = BundleLoader.LoadAssetBundle("hideoutcat_props");
            _herring = Object.Instantiate(bundle!.LoadAsset<GameObject>("herring_opened"));
            BundleLoader.ReplaceShadersToNative(_herring);
        }

        _herring!.SetActive(Plugin.GetAreaLevel(area) > 0);
        _herring.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);

        _herring.transform.position = Plugin.GetAreaLevel(area) switch
        {
            1 => new Vector3(5.5347f, 0.848f, -5.6833f),
            2 or 3 => new Vector3(5.432f, 0.759f, -4.9755f),
            _ => _herring.transform.position
        };
    }

    private static void HideUnwantedSceneObjects()
    {
        HideoutArea? heatingArea = null;
        var areasForHeating = Patches.HideoutAwakePatch.GetAreas();
        if (areasForHeating == null) { return; }

        foreach (var x in areasForHeating)
        {
            if (x.Value.AreaTemplate.Type != EAreaType.Heating) { continue; }

            heatingArea = x.Value;
            break;
        }

        if (heatingArea != null)
        {
            switch (Plugin.GetAreaLevel(heatingArea))
            {
                case 1:
                {
                    Disable(heatingArea.HighlightTransform.Find("books_01 (1)"));
                    break;
                }

                case 2:
                {
                    Disable(heatingArea.HighlightTransform.Find("books_01 (2)"));
                    break;
                }

                case 3:
                {
                    Disable(heatingArea.HighlightTransform.Find("paper3 (1)"));
                    Disable(heatingArea.HighlightTransform.Find("paper3 (2)"));
                    Disable(heatingArea.HighlightTransform.Find("Firewood_4 (7)"));
                    Disable(heatingArea.HighlightTransform.Find("Firewood_4 (6)"));
                    break;
                }
            }
        }

        HideoutArea? kitchenArea = null;
        foreach (var areaData in areasForHeating)
        {
            if (areaData.Value.AreaTemplate.Type != EAreaType.Kitchen) { continue; }

            kitchenArea = areaData.Value;
            break;
        }

        if (kitchenArea == null) { return; }

        switch (Plugin.GetAreaLevel(kitchenArea))
        {
            case 1:
            {
                Disable(kitchenArea.HighlightTransform.Find("dish_1"));
                break;
            }

            case 2:
            {
                Disable(kitchenArea.HighlightTransform.Find("dish_1 (1)"));
                Disable(kitchenArea.HighlightTransform.Find("fork (1)"));
                break;
            }

            case 3:
            {
                Disable(kitchenArea.HighlightTransform.Find("dish_1 (4)"));
                Disable(kitchenArea.HighlightTransform.Find("fork (2)"));
                break;
            }
        }
    }

    private static void Disable(Transform transform)
    {
        if (transform)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
