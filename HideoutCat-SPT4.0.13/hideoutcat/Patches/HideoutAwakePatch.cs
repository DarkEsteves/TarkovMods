using Comfort.Common;
using EFT;
using EFT.Hideout;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HideoutCat.Patches;

public class HideoutAwakePatch : ModulePatch
{
    public static event Action OnHideoutAwake;

    private static HideoutController _controller;

    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(HideoutController), nameof(HideoutController.HideoutAwake));
    }

    [PatchPostfix]
    private static void Postfix(HideoutController __instance)
    {
        _controller = __instance;
        OnHideoutAwake?.Invoke();
    }

    /// <summary>
    /// 4.0.13: HideoutController is a plain MonoBehaviour (not a Singleton).
    /// Returns the Areas dictionary captured when the hideout woke up.
    /// </summary>
    public static Dictionary<EAreaType, HideoutArea> GetAreas()
    {
        return _controller != null ? _controller.Areas : null;
    }

    public static HideoutController GetController()
    {
        if (_controller == null)
        {
            _controller = UnityEngine.Object.FindObjectOfType<HideoutController>();
        }
        return _controller;
    }
}
