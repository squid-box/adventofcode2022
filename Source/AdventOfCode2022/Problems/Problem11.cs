namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/11">Day 11</a>.
/// </summary>
public class Problem11 : ProblemBase
{
    public Problem11(InputDownloader inputDownloader) : base(11, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return SolvePartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return SolvePartTwo(Input);
    }

    internal static long SolvePartOne(ICollection<string> input)
    {
        var monkeys = ParseMonkeys(input);

        for (var round = 0; round < 20; round++)
        {
            foreach (var monkey in monkeys)
            {
                var itemsThrown = monkey.Value.ExecuteRound();

                foreach (var kvp in itemsThrown)
                {
                    monkeys[kvp.Key].ReceiveItems(kvp.Value);
                }
            }
        }

        return monkeys.Values
            .OrderByDescending(m => m.Inspections)
            .Take(2)
            .Select(m => m.Inspections)
            .Aggregate((x, y) => x * y);
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        var monkeys = ParseMonkeys(input);

        var commonMultiple = monkeys.Values.Select(m => m.TestValue).Aggregate(1, (x, y) => x * y);

        foreach (var monkey in monkeys.Values)
        {
            monkey.CommonMultiple = commonMultiple;
        }

        for (var round = 0; round < 10000; round++)
        {
            foreach (var monkey in monkeys)
            {
                var itemsThrown = monkey.Value.ExecuteRound();

                foreach (var kvp in itemsThrown)
                {
                    monkeys[kvp.Key].ReceiveItems(kvp.Value);
                }
            }
        }

        return monkeys.Values
            .OrderByDescending(m => m.Inspections)
            .Take(2)
            .Select(m => m.Inspections)
            .Aggregate((x, y) => x * y);
    }

    private static IDictionary<int, Monkey> ParseMonkeys(ICollection<string> input)
    {
        var monkeys = new Dictionary<int, Monkey>();

        foreach (var monkeyInput in input.SplitByBlankLines())
        {
            var id = Convert.ToInt32(monkeyInput[0].Split(' ')[1].Replace(":", string.Empty));
            var items = monkeyInput[1][18..].Split(", ").AsLong();
            var operation = monkeyInput[2][23..];
            var testValue = Convert.ToInt32(monkeyInput[3].Split(' ').Last());
            var trueTarget = Convert.ToInt32(monkeyInput[4].Split(' ').Last());
            var falseTarget = Convert.ToInt32(monkeyInput[5].Split(' ').Last());

            monkeys.Add(id, new Monkey(items, testValue, trueTarget, falseTarget, operation));
        }

        return monkeys;
    }

    private class Monkey
    {
        private readonly int _trueTarget;
        private readonly int _falseTarget;
        private readonly string _operation;
        private readonly List<long> _items;

        public Monkey(IEnumerable<long> startingItems, int testValue, int trueTarget, int falseTarget, string operation)
        {
            TestValue = testValue;
            Inspections = 0;

            _items = new List<long>(startingItems);
            _trueTarget = trueTarget;
            _falseTarget = falseTarget;
            _operation = operation;
        }

        public long Inspections { get; private set; }

        public long CommonMultiple { get; set; }

        public int TestValue { get; }

        public Dictionary<int, List<long>> ExecuteRound()
        {
            var itemDestinationList = new Dictionary<int, List<long>>
            {
                { _falseTarget, new List<long>() },
                { _trueTarget, new List<long>() }
            };

            foreach (var item in _items)
            {
                var worryLevel = InspectItem(item);

                if (worryLevel % TestValue == 0)
                {
                    itemDestinationList[_trueTarget].Add(worryLevel);
                }
                else
                {
                    itemDestinationList[_falseTarget].Add(worryLevel);
                }

                Inspections++;
            }

            _items.Clear();

            return itemDestinationList;
        }

        public void ReceiveItems(IEnumerable<long> items)
        {
            _items.AddRange(items);
        }

        private long InspectItem(long itemWorryLevel)
        {
            var split = _operation.Split(' ');
            var value = itemWorryLevel;

            if (!split[1].Equals("old", StringComparison.OrdinalIgnoreCase))
            {
                value = Convert.ToInt32(split[1]);
            }

            long newValue;

            if (split[0].Equals("+"))
            {
                newValue = itemWorryLevel + value;
            }
            else
            {
                newValue = itemWorryLevel * value;
            }

            if (CommonMultiple == 0)
            {
                newValue = (long)Math.Floor(newValue / 3d);
            }
            else
            {
                newValue %= CommonMultiple;
            }

            return newValue;
        }
    }
}