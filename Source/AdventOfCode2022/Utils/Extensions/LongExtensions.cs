namespace AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Extensions for longs.
/// </summary>
public static class LongExtensions
{
    /// <summary>
    /// Determines if the long is within a given (inclusive) range.
    /// </summary>
    /// <param name="val">Value to check.</param>
    /// <param name="lowerBound">Lower bound (inclusive).</param>
    /// <param name="upperBound">Upper bound (inclusive).</param>
    /// <returns>True if the integer is within the given range, otherwise false.</returns>
    public static bool IsWithin(this long val, long lowerBound, long upperBound)
    {
        return lowerBound <= val && val <= upperBound;
    }
}