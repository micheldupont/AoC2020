using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day15
	{
		public int Run(string input, int turnCount = 2020)
		{
			var numbers = input.Split(",").Select(int.Parse).ToList();

			var turn = numbers.Count + 1;

			while (turn <= turnCount)
			{
				var lastNumber = numbers[^1];
				var saidBeforeAtIndex = numbers.FindLastIndex(numbers.Count - 2, n => n == lastNumber);

				if (saidBeforeAtIndex == -1) //first time
				{
					numbers.Add(0);
				}
				else
				{
					var age = numbers.Count - 1 - saidBeforeAtIndex;
					numbers.Add(age);
				}

				turn += 1;
			}

			return numbers.Last();
		}

		public long Run2(string input)
		{
			var target = 30000000;

			var parsedNumbers = input.Split(",").Select(int.Parse).ToArray();

			var numberDictionary = new Dictionary<long, long>(); // dict : key: number / value: last index seen

			for (var i = 0; i < parsedNumbers.Length - 1; i++)
			{
				numberDictionary.Add(parsedNumbers[i], i);
			}

			var turn = parsedNumbers.Length;
			long lastNumber = parsedNumbers[^1];

			while (turn < target)
			{
				if (!numberDictionary.TryGetValue(lastNumber, out var saidBeforeAtIndex))
				{
					numberDictionary[lastNumber] = turn - 1;
					lastNumber = 0;
				}
				else
				{
					var age = turn - 1 - saidBeforeAtIndex;

					numberDictionary[lastNumber] = turn - 1;
					lastNumber = age;
				}

				turn += 1;
			}

			return lastNumber;
		}
	}
}