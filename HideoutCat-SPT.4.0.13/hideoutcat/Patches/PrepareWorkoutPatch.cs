using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace HideoutCat.Patches;

public class PrepareWorkoutPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(HideoutPlayerOwner), nameof(HideoutPlayerOwner.PrepareWorkout));
    }

    [PatchPostfix]
    private static void Postfix()
    {
        try { BepInExPlayerEvents.Instance.TriggerPlayerWorkoutPrepare(); }
        catch (System.Exception ex) { Plugin.Log.LogError(ex); }
    }
}
