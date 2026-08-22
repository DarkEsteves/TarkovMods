using EFT.Hideout;
using System;

namespace HideoutCat;

internal class BepInExPlayerEvents : IPlayerEvents
{
    public static BepInExPlayerEvents Instance { get; private set; } = new();

    public event Action<HideoutArea> AreaSelected;
    public event Action<HideoutArea> AreaLevelUpdated;
    public event Action PlayerPrepareWorkout;
    public event Action PlayerStopWorkout;

    public void TriggerAreaSelected(HideoutArea area) => AreaSelected?.Invoke(area);
    public void TriggerAreaLevelUpdated(HideoutArea area) => AreaLevelUpdated?.Invoke(area);
    public void TriggerPlayerWorkoutPrepare() => PlayerPrepareWorkout?.Invoke();
    public void TriggerPlayerWorkoutStop() => PlayerStopWorkout?.Invoke();
}
