namespace advent_of_code;

public class Day4 : Day
{
    protected override string FileName => "day4";
    
    protected override string SolvePartOne(ICollection<string> input)
    {
        var result = 0;
        
        foreach (var line in input)
        {
            var (range1, range2) = GetRanges(line);

            if (Contains(range1, range2))
                result++;
        }

        return result.ToString();
    }

    protected override string SolvePartTwo(ICollection<string> input)
    {
        var result = 0;
        
        foreach (var line in input)
        {
            var (range1, range2) = GetRanges(line);

            if (Overlaps(range1, range2))
                result++;
        }

        return result.ToString();
    }

    private ((int start, int end) range1, (int start, int end) range2) GetRanges(string line)
    {
        var elves = line.Split(",");

        var elf1 = elves[0].Split("-");
        var elf2 = elves[1].Split("-");

        var range1 = (int.Parse(elf1[0]), int.Parse(elf1[1]));
        var range2 = (int.Parse(elf2[0]), int.Parse(elf2[1]));

        return (range1, range2);
    }
    
    private bool Contains((int start, int end) range1, (int start, int end) range2)
    {
        var (range1Start, range1End) = range1;
        var (range2Start, range2End) = range2;
        
        // 1 contains 2
        if (range1Start <= range2Start && range2End <= range1End)
            return true;
        
        // 2 contains 1
        if (range2Start <= range1Start && range1End <= range2End)
            return true;

        return false;
    }
    
    private bool Overlaps((int start, int end) range1, (int start, int end) range2)
    {
        var (range1Start, range1End) = range1;
        var (range2Start, range2End) = range2;
        
        // 1 overlaps 2
        if (range1Start <= range2Start && range2Start <= range1End)
            return true;
        
        // 2 overlaps 1
        if (range2Start <= range1Start && range1Start <= range2End)
            return true;

        return false;
    }
}