using AOC2024;
using Xunit.Abstractions;

namespace Tests;

public class Day3Tests(ITestOutputHelper testOutputHelper)
{
    private readonly Fixture _fixture = new(testOutputHelper);

    [Fact]
    public void Day3Example1()
    {
        var day = _fixture.Prepare<Day3>();
        var result = day.SolvePart1(["xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"]);
        Assert.Equal(161, result);
    }

    [Fact]
    public void Day3TaskA()
    {
        var input = _fixture.GetTestFileLines("day3A.txt");
        var day = _fixture.Prepare<Day3>();
        var result = day.SolvePart1(input);
        Assert.Equal(178886550, result);
    }

    [Fact]
    public void Day3Example2()
    {
        //mul\(\d+,\d+\)|do\(\)|don't\(\)
        var day = _fixture.Prepare<Day3>();
        var result = day.SolvePart2(["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"]);
        Assert.Equal(48, result);
    }

    [Fact]
    public void Day3TaskB()
    {
        var input = _fixture.GetTestFileLines("day3A.txt");
        var day = _fixture.Prepare<Day3>();
        var result = day.SolvePart2(input);
        Assert.Equal(87163705, result);
    }
}