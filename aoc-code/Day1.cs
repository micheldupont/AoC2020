using System;
using System.Linq;

namespace aoc_code
{
	public class Day1
	{
		public int Run(string inputStr)
		{
			var inputs = inputStr.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s))
				.OrderBy(n => n).ToArray();

			for (var i = 0; i < inputs.Length - 2; i++)
			{
				var thisNumber = inputs[i];
				var j = i + 1;

				var thatNumber = inputs[j];
				var sum = thisNumber + thatNumber;
				var target = 2020;

				while (sum < target)
				{
					j += 1;
					thatNumber = inputs[j];
					sum = thisNumber + thatNumber;
				}

				if (sum == target) return thisNumber * thatNumber;
			}

			return -1;
		}

		public int Run2(string inputStr)
		{
			var inputs = inputStr.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s))
				.OrderBy(n => n).ToArray();

			var target = 2020;

			for (var i = 0; i < inputs.Length - 3; i++)
			{
				var thisNumber = inputs[i];

				for (var j = i + 1; j < inputs.Length - 2; j++)
				{
					var thatNumber = inputs[j];

					for (var k = j + 1; k < inputs.Length - 1; k++)
					{
						var thatOtherNumber = inputs[k];

						var sum = thisNumber + thatNumber + thatOtherNumber;

						if (sum == target) return thisNumber * thatNumber * thatOtherNumber;

						if (sum > target) break;
					}
				}
			}

			return -1;
		}
	}
}