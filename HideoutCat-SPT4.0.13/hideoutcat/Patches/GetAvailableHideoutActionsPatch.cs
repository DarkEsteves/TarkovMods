using EFT;
using EFT.Hideout;
using HideoutCat.CatData;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HideoutCat.Patches;

public class GetAvailableHideoutActionsPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(GetActionsClass), nameof(GetActionsClass.GetAvailableHideoutActions));
    }

    [PatchPrefix]
    private static bool Prefix(ref ActionsReturnClass __result, HideoutPlayerOwner owner, GInterface177 interactive)
    {
        var cat = interactive as Cat;
        if (cat == null) return true;

        __result = GetCatAvailableActions(cat, owner);
        return false;
    }

    public static ActionsReturnClass GetCatAvailableActions(Cat cat, HideoutPlayerOwner owner)
    {
        var result = new ActionsReturnClass
        {
            Actions = new List<ActionsTypesClass>()
        };

        result.Actions.Add(new ActionsTypesClass
        {
            Name = "Pet",
            Action = new Action(delegate
            {
                cat.Pet();
                owner.Player.SetInteractInHands(EInteraction.ContainerOpenDefault);
                owner.InteractionsChangedHandler();
            }),
            Disabled = !cat.IsPettable()
        });

        result.Actions.Add(new ActionsTypesClass
        {
            Name = "Wake up",
            Action = new Action(delegate
            {
                cat.WakeUp();
                owner.InteractionsChangedHandler();
            }),
            Disabled = !cat.IsSleeping()
        });

        return result;
    }
}
