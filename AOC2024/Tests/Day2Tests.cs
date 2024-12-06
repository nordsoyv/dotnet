using AOC2024;
using Xunit.Abstractions;

namespace Tests;

public class Day2Tests(ITestOutputHelper testOutputHelper)
{
    private readonly Fixture _fixture = new(testOutputHelper);

    [Fact]
    public void Day2Example1()
    {
        var day = _fixture.Prepare<Day2>();
        var result = day.SolvePart1([
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9",
        ]);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Day2TaskA()
    {
        var input = _fixture.GetTestFileLines("day2A.txt");
        var day = _fixture.Prepare<Day2>();
        var result = day.SolvePart1(input);
        Assert.Equal(564, result);
    }

    [Fact]
    public void Day2Example2()
    {
        var day = _fixture.Prepare<Day2>();
        var result = day.SolvePart2([
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9",
        ]);
        Assert.Equal(4, result);
    }

    [Fact]
    public void Day2TaskB()
    {
        var input = _fixture.GetTestFileLines("day2A.txt");
        var day = _fixture.Prepare<Day2>();
        var result = day.SolvePart2(input);
        Assert.Equal(604, result);
    }
}