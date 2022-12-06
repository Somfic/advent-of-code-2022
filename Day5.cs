using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace advent_of_code;

public class Day5 : Day
{
    protected override string FileName => "day5";
    
    protected override string SolvePartOne(ICollection<string> input)
    {
        var cratesInput = FindCratesInput(input);
        var commandsInput = FindCommandsInput(input);
        
        var crates = FindCrates(cratesInput.ToArray());

        var regex = new Regex("move ([0-9]+) from ([0-9]+) to ([0-9]+)");
        foreach (var command in commandsInput)
        {
            var match = regex.Match(command);

            var amountToMove = int.Parse(match.Groups[1].Value);
            var moveFromCrate =  int.Parse(match.Groups[2].Value);
            var moveToCrate = int.Parse(match.Groups[3].Value);

            for (var i = 0; i < amountToMove; i++)
            {
                crates = PerformMove(crates, moveFromCrate, moveToCrate);
            }
        }

        var topCrates = new char[crates.Length];
        for (var index = 0; index < crates.Length, index++)
        {
            topCrates[index] = GetTopCrate(crates, index);
        }

        return string.Join(", ", topCrates);
    }

    private char[,] PerformMove(char[,] crates, int from, int to)
    {
        return crates;
    }

    private char GetTopCrate(char[,] crates, int x)
    {
        return crates[0,x];
    }

    private ICollection<string> FindCratesInput(ICollection<string> input)
    {
        var result = new List<string>();

        foreach (var line in input)
        {
            result.Add(line);

            if (string.IsNullOrWhiteSpace(line))
                break;
        }

        return result;
    }

    private ICollection<string> FindCommandsInput(ICollection<string> input)
    {
        var result = new List<string>();

        var shouldAdd = false;
        
        foreach (var line in input)
        {
            if(shouldAdd)
                result.Add(line);

            if (string.IsNullOrWhiteSpace(line))
                shouldAdd = true;
        }

        return result;
    }

    private char[,] FindCrates(ICollection<string> input)
    {
        var width = input.Count - 2;
        var height = (int)Math.Ceiling((input.Select(x => x.Length).Max() - 1f) / 4f);
        
        var crates = new char[width, height];
        
        for (var lineIndex = 0; lineIndex < input.Count; lineIndex++)
        {
            var line = input.ElementAt(lineIndex);

            var actualIndex = 0;
            for (var index = 1; index < line.Length; index += 4)
            {
                var character = line[index];

                if(char.IsLetter(character)) 
                    crates[lineIndex,actualIndex] = line[index];
                
                actualIndex++;
            }
            
            if (string.IsNullOrWhiteSpace(line))
                break;
        }

        return crates;
    }

    protected override string SolvePartTwo(ICollection<string> input)
    {
        return string.Empty;
    }
}