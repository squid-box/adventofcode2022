namespace AdventOfCode2022.Utils.Extensions;

using System.Collections.Generic;

public static class QueueExtensions
{
    public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> range)
    {
        foreach (var item in range)
        {
            queue.Enqueue(item);
        }
    }
}