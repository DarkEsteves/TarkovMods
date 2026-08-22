using EFT.Hideout;
using HideoutCat.Pathfinding;
using System;

namespace HideoutCat;

public interface IPlayerEvents
{
    public event Action<HideoutArea> AreaSelected;
    public event Action<HideoutArea> AreaLevelUpdated;
    public event Action PlayerPrepareWorkout;
    public event Action PlayerStopWorkout;
}

public static class CatDependencyProviders
{
    public static Graph CatGraph { get; private set; }
    public static IPlayerEvents PlayerEvents { get; private set; }

    public static bool IsInitialized => CatGraph != null && PlayerEvents != null;

    public static void Initialize(Graph catGraph, IPlayerEvents playerEventsProvider)
    {
        CatGraph = catGraph;
        PlayerEvents = playerEventsProvider;
    }
}
