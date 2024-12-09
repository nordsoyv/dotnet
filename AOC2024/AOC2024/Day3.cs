using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AOC2024;

public class Day3(Action<string> writeLine) : Day(writeLine)
{
    public Day3() : this(s => { })
    {
    }

    public override int SolvePart1(List<string> input)
    {
        var sum = 0;
        foreach (var line in input)
        {
            var regex = new Regex("mul\\(\\d+,\\d+\\)");
            var match = regex.Matches(line);
            var numberRegex = new Regex("\\d+");
            foreach (Match o in match)
            {
                //WriteLine(o.Value);
                var numbers = numberRegex.Matches(o.Value);
                var num1 = int.Parse(numbers[0].Value);
                var num2 = int.Parse(numbers[1].Value);
                var calc = num1 * num2;
                WriteLine($"{o.Value} : {num1} * {num2} = {calc}");
                sum += calc;
            }

        }

        WriteLine(sum.ToString());
        return sum;
    }

    public override int SolvePart2(List<string> input)
    {
        var sum = 0;
        var shouldDo = true;
        foreach (var line in input)
        {
            var regex = new Regex("mul\\(\\d+,\\d+\\)|do\\(\\)|don't\\(\\)");
            var match = regex.Matches(line);
            var numberRegex = new Regex("\\d+");
            foreach (Match o in match)
            {
                //WriteLine(o.Value);
                if (o.Value == "do()")
                {
                    shouldDo = true;
                    continue;
                }

                if (o.Value == "don't()")
                {
                    shouldDo = false;
                    continue;
                }

                if (shouldDo)
                {
                    var numbers = numberRegex.Matches(o.Value);
                    var num1 = int.Parse(numbers[0].Value);
                    var num2 = int.Parse(numbers[1].Value);
                    var calc = num1 * num2;
                    WriteLine($"{o.Value} : {num1} * {num2} = {calc}");
                    sum += calc;
                }
                
            }

        }

        WriteLine(sum.ToString());
        return sum;
    }
}


