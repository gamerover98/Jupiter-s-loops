namespace Api.Common
{
    public static class MathUtil
    {
        /// <summary>Trims the float value to the specified precision.</summary>
        /// <param name="value">The float value to be trimmed.</param>
        /// <param name="precision">The precision to which the float value should be trimmed.</param>
        /// <returns>The trimmed float value.</returns>
        public static float TrimFloat(float value, int precision)
        {
            return (int) (value * precision) / (float) precision;
        }
    }
}