namespace HideoutCat.Extensions;

public static class FloatExtensions
{
    public static float RemapClamped(this float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        if (value < fromMin)
        {
            value = fromMin;
        }
        else if (value > fromMax)
               {
            value = fromMax;
        }

        return value.Remap(fromMin, fromMax, toMin, toMax);
    }

    private static float Remap(this float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        if (fromMax - fromMin == 0f)
        {
            return (toMin + toMax) / 2f;
        }

        return toMin + (value - fromMin) / (fromMax - fromMin) * (toMax - toMin);
    }
}
