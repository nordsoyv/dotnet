using AOC2024;
using Xunit.Abstractions;

namespace Tests;

public class DayTests(ITestOutputHelper testOutputHelper)
{
    private readonly Fixture _fixture = new(testOutputHelper);

    [Fact]
    public void Day1Example1()
    {
        var day = _fixture.Prepare<Day1>();
        var result = day.SolvePart1([
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"
        ]);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Day1TaskA()
    {
        var input = _fixture.GetTestFileLines("day1A.txt");
        var day = _fixture.Prepare<Day1>();
        var result = day.SolvePart1(input);
        Assert.Equal(1223326, result);
    }

    [Fact]
    public void Day1Example2()
    {
        var day = _fixture.Prepare<Day1>();
        var result = day.SolvePart2([
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"
        ]);
        Assert.Equal(31, result);
    }

    [Fact]
    public void Day1TaskB()
    {
        var input = _fixture.GetTestFileLines("day1A.txt");
        var day = _fixture.Prepare<Day1>();
        var result = day.SolvePart2(input);
        Assert.Equal(21070419, result);
    }
}