using UnityEngine;

namespace HideoutCat.Utils;

public static class IntervalUtils
{
    private static bool RandomShouldOccur(float avgIntervalSeconds, float deltaTime)
    {
        if (avgIntervalSeconds <= 0f) { return true; }

        var probability = deltaTime / avgIntervalSeconds;
        return Random.value < probability;
    }

    public static bool RandomShouldOccur(float avgIntervalSeconds)
    {
        return RandomShouldOccur(avgIntervalSeconds, Time.fixedDeltaTime);
    }

    /// <summary>
    /// Meow frequency slider: lower value = more frequent meows.
    /// Uses an accumulator so the slider feels responsive across the full 10-300s range.
    /// </summary>
    private static float _meowAccumulator;

    public static bool ShouldMeowByFrequency(float avgIntervalSeconds, float deltaTime)
    {
        if (avgIntervalSeconds <= 0f) return true;

        _meowAccumulator += deltaTime;
        if (_meowAccumulator >= avgIntervalSeconds)
        {
            _meowAccumulator = 0f;
            return true;
        }
        return false;
    }

    public static bool ShouldMeowByFrequency(float avgIntervalSeconds)
    {
        return ShouldMeowByFrequency(avgIntervalSeconds, Time.fixedDeltaTime);
    }
}