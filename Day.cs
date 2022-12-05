namespace advent_of_code;

public abstract class Day
{
    private readonly string _inputFileName;

    protected abstract string FileName { get; }

    protected abstract string SolvePartOne(ICollection<string> input);
    protected abstract string SolvePartTwo(ICollection<string> input);

    public (string partOne, string partTwo) Solve()
    {
        var input = File.ReadAllLines(Path.Combine("inputs", FileName));

        return (SolvePartOne(input), SolvePartTwo(input));
    }
}