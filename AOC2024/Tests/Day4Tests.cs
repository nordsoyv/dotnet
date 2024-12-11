using AOC2024;
using Xunit.Abstractions;

namespace Tests;

public class Day4Tests(ITestOutputHelper testOutputHelper)
{
    private readonly Fixture _fixture = new(testOutputHelper);

    [Fact]
    public void Day4Example1()
    {
        var day = _fixture.Prepare<Day4>();
        var result = day.SolvePart1([
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
        ]);
        Assert.Equal(18, result);
    }

    [Fact]
    public void Day4TaskA()
    {
        var input = _fixture.GetTestFileLines("day4A.txt");
        var day = _fixture.Prepare<Day4>();
        var result = day.SolvePart1(input);
        Assert.Equal(2427, result);
    }

    [Fact]
    public void Day4Example2()
    {
        var day = _fixture.Prepare<Day4>();
        var result = day.SolvePart2([
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
        ]);
        Assert.Equal(9, result);
    }

    [Fact]
    public void Day4TaskB()
    {
        var input = _fixture.GetTestFileLines("day4A.txt");
        var day = _fixture.Prepare<Day4>();
        var result = day.SolvePart2(input);
        Assert.Equal(1900, result);
    }
}