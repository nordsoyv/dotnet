using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AOC2024;

public class Day2(Action<string> writeLine) : Day(writeLine)
{
    public Day2() : this(s => { })
    {
    }

    public override int SolvePart1(List<string> input)
    {
        var numbers = input.Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList();
        var count = numbers.Select(num =>
        {
            var n = new Numbers(num);
            return n.IsIncreasing() || n.IsDecreasing();
        }).Count(i => i);
        return count;
    }

    public override int SolvePart2(List<string> input)
    {
        var numbers = input.Select(line => line.Split(" ").Select(int.Parse).ToImmutableList()).ToList();
        var count = numbers.Select(num =>
        {
            var n = new Numbers(num);
            var isSafe = n.IsIncreasing() || n.IsDecreasing();
            if (isSafe)
            {
                return isSafe;
            }

            for (int i = 0; i < num.Count; i++)
            {
                var listWithItemRemoved = num.RemoveAt(i);
                n = new Numbers(listWithItemRemoved);
                isSafe = n.IsIncreasing() || n.IsDecreasing();
                if (isSafe)
                {
                    return isSafe;
                }
            }

            return false;
        }).Count(i => i);
        return count;
    }
}


internal class Numbers
{
    private IEnumerable<int> _numbers;

    public Numbers(IEnumerable<int> numbers)
    {
        _numbers = numbers;
    }

    public bool IsIncreasing()
    {
        for (int i = 0; i < _numbers.Count()-1; i++)
        {
            var num = _numbers.ElementAt(i);
            var next = _numbers.ElementAt(i + 1);
            if (num < next)
            {
                if (next - num < 4)
                    continue;
            }

            return false;
        }

        return true;
    }
    public bool IsDecreasing()
    {
        for (int i = 0; i < _numbers.Count()-1; i++)
        {
            var num = _numbers.ElementAt(i);
            var next = _numbers.ElementAt(i + 1);
            if (num > next)
            {
                if (num - next < 4)
                    continue;
            }

            return false;
        }

        return true;
    }
}