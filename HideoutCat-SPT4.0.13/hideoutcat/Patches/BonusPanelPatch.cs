using EFT.Hideout;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HideoutCat.Patches;

public class BonusPanelPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(BonusPanel), nameof(BonusPanel.UpdateView));
    }

    [PatchPostfix]
    private static void Postfix(BonusPanel __instance, SkillBonusAbstractClass ___skillBonusAbstractClass,
        TextMeshProUGUI ____description, TextMeshProUGUI ____effect)
    {
        if (___skillBonusAbstractClass == null) return;
        if (___skillBonusAbstractClass.Id.ToString() != "64f5b9e5fa34f11b380756d6") return;

        if (____description) ____description.text = "Unlocks cat";
        if (____effect) ____effect.text = "";
    }
}
