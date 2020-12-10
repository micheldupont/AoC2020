using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_code
{
	public class Day9
	{
		public long Run(string input, int size)
		{
			var inputs = input.Split("\r\n").Select(l => long.Parse(l)).ToArray();

			return FindWeakness(inputs, size);
		}

		public long Run2(string input, int size)
		{
			var inputs = input.Split("\r\n").Select(l => long.Parse(l)).ToArray();

			var weakness = FindWeakness(inputs, size);

			var interestingArray = inputs.FindSubSetThatSumsTo(weakness);

			if (interestingArray != null) return interestingArray.Min() + interestingArray.Max();

			return -1;
		}

		private long FindWeakness(long[] inputs, int size)
		{
			var preambleIndex = 0;
			var dataIndex = size;

			while (dataIndex < inputs.Length)
			{
				var preambleData = inputs.Skip(preambleIndex).Take(size).OrderBy(i => i).ToArray();
				var currentNumber = inputs[dataIndex];

				if (!preambleData.HasTwoItemsThatSumsTo(currentNumber)) return currentNumber;

				preambleIndex += 1;
				dataIndex += 1;
			}

			return -1;
		}
	}

	public static class ArrayExtensions
	{
		public static bool HasTwoItemsThatSumsTo(this long[] array, long target)
		{
			for (var i = 0; i < array.Length; i++)
			{
				var current = array[i];
				if (current >= target) return false;

				for (var j = i + 1; j < array.Length; j++)
				{
					var testing = array[j];
					var sum = current + testing;

					if (sum > target) break;

					if (sum == target) return true;
				}
			}

			return false;
		}

		public static long[] FindSubSetThatSumsTo(this long[] array, long target)
		{
			for (var size = 2; size < array.Length; size++)
			for (var startIndex = 0; startIndex < array.Length - size + 1; startIndex++)
			{
				var trying = array.Skip(startIndex).Take(size).ToArray();
				var sum = trying.Sum();
				if (sum == target) return trying;
			}

			return null;
		}
	}
}