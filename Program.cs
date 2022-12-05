using advent_of_code;

var days = new Day[] { new Day1(), new Day2(), new Day3(), new Day4() };

for (var index = 0; index < days.Length; index++)
{
    var day = days[index];
    var (partOne, partTwo) = day.Solve();
    
    Console.WriteLine($"{index + 1}.1: {partOne}");
    Console.WriteLine($"  2: {partTwo}");
    Console.WriteLine();
}