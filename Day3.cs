namespace advent_of_code;

public class Day3 : Day
{
    protected override string FileName => "day3";
    
    protected override string SolvePartOne(ICollection<string> input)
    {
        var result = 0;
        
        foreach (var line in input)
        {
            var half = line.Length / 2;
            var compartment1 = line[..half].ToCharArray();
            var compartment2 = line[half..].ToCharArray();

            var common = compartment1.Intersect(compartment2).First();
            
            result += GetPriority(common);
        }

        return result.ToString();
    }

    protected override string SolvePartTwo(ICollection<string> input)
    {
        var result = 0;
        
        for (var index = 0; index < input.Count; index+=3)
        {
            var elf1 = input.ElementAt(index);
            var elf2 = input.ElementAt(index + 1);
            var elf3 = input.ElementAt(index + 2);

            var identifier = elf1.Intersect(elf2).Intersect(elf3).First();

            result += GetPriority(identifier);
        }

        return result.ToString();
    }

    private int GetPriority(char character)
    {
        var priority = character - 96;
        if (priority < 0)
            priority += 58;

        return priority;
    }
}