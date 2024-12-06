using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024;

public class Day1(Action<string> writeLine)  : Day(writeLine)
{
    public Day1() : this(s => {})
    {
        
    }

    public override int SolvePart1(List<string> input)
    {
        List<int> list1 = [];
        List<int> list2 = [];
        input.ForEach(line =>
        {
            var parts = line.Split("   ");
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        });
        list1.Sort();
        list2.Sort();

        return list1.Zip(list2).ToList().Select(pair =>
        {
            var first = pair.First;
            var second = pair.Second;
            var distance = Math.Abs(first - second);
            return distance;
        }).Sum();
    }

    public override int SolvePart2(List<string> input)
    {
        List<int> list1 = [];
        List<int> list2 = [];
        input.ForEach(line =>
        {
            var parts = line.Split("   ");
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        });
        return list1.Select(item =>
        {
            var count = list2.FindAll(item2 => item == item2).Count;
            return count * item;
        }).Sum();
    }
}