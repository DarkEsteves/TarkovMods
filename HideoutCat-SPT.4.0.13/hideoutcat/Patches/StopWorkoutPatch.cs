using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace HideoutCat.Patches;

public class StopWorkoutPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(HideoutPlayerOwner), nameof(HideoutPlayerOwner.StopWorkout));
    }

    [PatchPostfix]
    private static void Postfix()
    {
        try { BepInExPlayerEvents.Instance.TriggerPlayerWorkoutStop(); }
        catch (System.Exception ex) { Plugin.Log.LogError(ex); }
    }
}
