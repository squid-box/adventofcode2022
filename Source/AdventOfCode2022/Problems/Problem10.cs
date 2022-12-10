namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Generic;
using AdventOfCode2022.Utils;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/10">Day 10</a>.
/// </summary>
public class Problem10 : ProblemBase
{
    public Problem10(InputDownloader inputDownloader) : base(10, inputDownloader) { }

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

    internal static int SolvePartOne(ICollection<string> input)
    {
        var cpu = new Cpu(new []{"X"});

        foreach (var line in input)
        {
            cpu.ExecuteInstruction(line);
        }

        return cpu.GetRegisterState("X", 20) * 20 +
               cpu.GetRegisterState("X", 60) * 60 +
               cpu.GetRegisterState("X", 100) * 100 +
               cpu.GetRegisterState("X", 140) * 140 +
               cpu.GetRegisterState("X", 180) * 180 +
               cpu.GetRegisterState("X", 220) * 220;
    }

    internal static string SolvePartTwo(ICollection<string> input)
    {
        var cpu = new Cpu(new[] { "X" });
        var crt = new Crt(cpu, 40, 6);

        foreach (var line in input)
        {
            cpu.ExecuteInstruction(line);
        }

        return Environment.NewLine + crt + Environment.NewLine;
    }

    private class Cpu
    {
        private readonly Dictionary<string, int> _registers;
        private readonly Dictionary<string, Dictionary<int, int>> _registerHistory;
        
        private int _currentCycle;

        internal event EventHandler<CpuCycleEventArgs> Cycle;

        public Cpu(IEnumerable<string> registers, int initialRegisterState = 1)
        {
            _currentCycle = 0;

            _registers = new Dictionary<string, int>();
            _registerHistory = new Dictionary<string, Dictionary<int, int>>();

            foreach (var register in registers)
            {
                _registers.Add(register, initialRegisterState);
                _registerHistory.Add(register, new Dictionary<int, int>());
            }
        }

        public void ExecuteInstruction(string instruction)
        {
            if (instruction.Equals("noop", StringComparison.OrdinalIgnoreCase))
            {
                Noop();
            }
            else if (instruction.StartsWith("add"))
            {
                var split = instruction.Split(' ');
                Add(split[0][3..], Convert.ToInt32(split[1]));
            }
        }

        public int GetRegisterState(string register, int atCycle)
        {
            return _registerHistory[register][atCycle];
        }

        private void Noop()
        {
            _currentCycle++;
            UpdateRegisterHistory();
        }

        private void Add(string register, int value)
        {
            _currentCycle++;
            UpdateRegisterHistory();
            _currentCycle++;
            UpdateRegisterHistory();

            _registers[register.ToUpperInvariant()] += value;
        }

        private void UpdateRegisterHistory()
        {
            foreach (var register in _registers)
            {
                _registerHistory[register.Key].Add(_currentCycle, register.Value);
            }

            Cycle?.Invoke(this, new CpuCycleEventArgs(_currentCycle, _registers));
        }
    }

    private class Crt
    {
        private readonly int _width;
        private readonly int _height;

        private Dictionary<Coordinate, char> _screen;

        public Crt(Cpu cpu, int width, int height)
        {
            _width = width;
            _height = height;

            _screen = new Dictionary<Coordinate, char>();

            cpu.Cycle += OnCpuCycle;
        }

        private void OnCpuCycle(object sender, CpuCycleEventArgs e)
        {
            var cycle = e.Cycle - 1;
            var coordinate = new Coordinate(cycle % _width, Convert.ToInt32(Math.Floor(cycle / (double)_width)));

            if (e.RegisterState["X"].IsWithin(coordinate.X - 1, coordinate.X + 1))
            {
                _screen[coordinate] = '#';
            }
            else
            {
                _screen[coordinate] = '.';
            }
        }

        public override string ToString()
        {
            var image = "";

            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    image += _screen[new Coordinate(x, y)];
                }

                image += Environment.NewLine;
            }

            return image.Trim();
        }
    }

    private class CpuCycleEventArgs : EventArgs
    {
        public CpuCycleEventArgs(int cycle, Dictionary<string, int> registerState)
        {
            Cycle = cycle;
            RegisterState = registerState;
        }

        public int Cycle { get; }

        public Dictionary<string, int> RegisterState { get; }
    }
}