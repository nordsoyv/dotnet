namespace AOC2024;

public abstract class Day(Action<string> writeLine)
{
    public Action<string> WriteLine { get; set; } = writeLine;
    public abstract int SolvePart1(List<string> input);
    public abstract int SolvePart2(List<string> input);
}