using advent_of_code;

public class Day1 : Day
{
	protected override string FileName => "day1";

	protected override string SolvePartOne(ICollection<string> input)
	{
		return SortElves(input).Max().ToString();
	}

	protected override string SolvePartTwo(ICollection<string> input)
	{
		return string.Join(", ", SortElves(input).Take(3));
	}

	private IEnumerable<int> SortElves(ICollection<string> input)
	{
		var elves = new List<int>() { 0 };

		foreach (var line in input)
		{
			if (string.IsNullOrWhiteSpace(line))
				elves.Add(0);
			else
				elves[^1] += int.Parse(line);
		}

		return elves.OrderByDescending(e => e);
	}
}