class Day1 {
	public static void Solve() {
		var lines = File.ReadAllLines(Path.Join("inputs", "day1"));
		var elves = new List<int>() { 0 };

		foreach (var line in lines)
		{
			if (string.IsNullOrWhiteSpace(line))
				elves.Add(0);
			else
				elves[elves.Count - 1] += int.Parse(line);
		}

		var topElf = elves.Max();
		var topThreeElves = elves.OrderByDescending(e => e).Take(3).Sum();

		Console.WriteLine($"Top Elf: {topElf}");
		Console.WriteLine($"Top Three Elves: {topThreeElves}");
	}
}