using advent_of_code;

public class Day2 : Day
{
	protected override string FileName => "day2";
	
	protected override string SolvePartOne(IEnumerable<string> input)
	{
		var score = 0;

		foreach (var line in input)
		{
			var inputs = line.Split(' ');
			var opponentHand = HandFromCharacter(inputs[0]);
			var ourHand = HandFromCharacter(inputs[1]);

			var result = ResultFromHands(ourHand, opponentHand);

			score += (int)ourHand + (int)result;
		}

		return score.ToString();
	}

	protected override string SolvePartTwo(IEnumerable<string> input)
	{
		var score = 0;

		foreach (var line in input)
		{
			var inputs = line.Split(' ');
			var opponentHand = HandFromCharacter(inputs[0]);
			
			var neededResult = ResultFromCharacter(inputs[1]);
			var ourHand = ChooseOurHand(neededResult, opponentHand);

			score += (int)ourHand + (int)neededResult;
		}

		return score.ToString();
	}

	private static Hand ChooseOurHand(Result neededResult, Hand opponentHand)
	{
		return neededResult switch
		{
			Result.Won => opponentHand switch
			{
				Hand.Rock => Hand.Paper,
				Hand.Paper => Hand.Scissors,
				Hand.Scissors => Hand.Rock,
				_ => throw new ArgumentOutOfRangeException(nameof(opponentHand))
			},
			
			Result.Draw => opponentHand,
			
			Result.Lost => opponentHand switch
			{
				Hand.Rock => Hand.Scissors,
				Hand.Paper => Hand.Rock,
				Hand.Scissors => Hand.Paper,
				_ => throw new ArgumentOutOfRangeException(nameof(opponentHand))
			},
			_ => throw new ArgumentOutOfRangeException(nameof(neededResult))
		};
	}

	static Result ResultFromHands(Hand ourHand, Hand opponentHand)
	{
		// Draw
		if (opponentHand == ourHand)
			return Result.Draw;

		// Lost
		if ((opponentHand == Hand.Rock && ourHand == Hand.Scissors) ||
		    (opponentHand == Hand.Scissors && ourHand == Hand.Paper) ||
		    (opponentHand == Hand.Paper && ourHand == Hand.Rock))
			return Result.Lost;

		// Won
		return Result.Won;
	}

	static Hand HandFromCharacter(string character)
	{
		switch (character[0])
		{
			case 'A':
			case 'X':
				return Hand.Rock;
			case 'B':
			case 'Y':
				return Hand.Paper;
			case 'C':
			case 'Z':
				return Hand.Scissors;
			default:
				throw new ArgumentOutOfRangeException(nameof(character));
		}
	}

	enum Hand
	{
		Rock = 1,
		Paper = 2,
		Scissors = 3
	}

	static Result ResultFromCharacter(string character)
	{
		return character[0] switch
		{
			'X' => Result.Lost,
			'Y' => Result.Draw,
			'Z' => Result.Won,
			_ => throw new ArgumentOutOfRangeException(nameof(character))
		};
	}

	enum Result
	{
		Won = 6,
		Draw = 3,
		Lost = 0,
	}
}