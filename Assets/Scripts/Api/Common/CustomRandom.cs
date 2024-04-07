using System;

namespace Api.Common
{
    /// <summary>
    /// CustomRandom is a subclass of Random that provides additional functionality.
    /// </summary>
    public class CustomRandom : Random
    {
        /// <summary>
        /// Initializes a new instance of the CustomRandom class.
        /// </summary>
        public CustomRandom()
        {
            // nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the CustomRandom class using the specified seed value.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence.</param>
        public CustomRandom(int seed) : base(seed)
        {
            // nothing to do.
        }

        /// <summary>
        /// Returns a random number between min and max, inclusive.
        /// <para>If min equals max, the result will be min.</para>
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>A random number between min and max, inclusive.</returns>
        public int NumberInRange(int min, int max)
        {
            if (min == max) return min;
            return min + Next(max - min + 1);
        }
    }
}