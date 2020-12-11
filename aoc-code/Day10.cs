using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day10
	{
		public int Run(string input)
		{
			var diffOf1Count = 0;
			var diffOf3Count = 1;

			var adapters = input.Split("\r\n").Select(int.Parse).OrderBy(a => a).ToArray();

			for (var i = 0; i < adapters.Length; i++)
			{
				var prev = i == 0 ? 0 : adapters[i - 1];
				var curr = adapters[i];

				var diff = curr - prev;
				if (diff == 1)
				{
					diffOf1Count += 1;
				}

				if (diff == 3)
				{
					diffOf3Count += 1;
				}
			}

			return diffOf1Count * diffOf3Count;
		}

		public ulong Run2(string input)
		{
			var adapters = input.Split("\r\n").Select(int.Parse).OrderBy(a => a).ToArray();
			adapters = new[] {0}.Concat(adapters).Concat(new[] {adapters.Last() + 3}).ToArray();

			var adaptersBunch = SplitInBunches(adapters);

			var total = adaptersBunch.Select(CalculatePermutations).Aggregate((a, b) => a * b);

			return total;
		}

		private static List<int[]> SplitInBunches(int[] adapters)
		{
			var adaptersBunch = new List<int[]>();

			var bunchIndex = 0;
			for (var i = 1; i < adapters.Length; i++)
			{
				var prev = adapters[i - 1];
				var curr = adapters[i];

				var diff = curr - prev;
				if (diff == 3)
				{
					adaptersBunch.Add(adapters.Skip(bunchIndex).Take(i - bunchIndex).ToArray());
					bunchIndex = i;
				}
			}

			return adaptersBunch;
		}

		public ulong CalculatePermutations(int[] values)
		{
			switch (values.Length)
			{
				case 1:
				case 2:
					return 1;
				case 3:
					return 2;
				case 4:
					return 4;
				case 5:
					return 7;
				default:
					throw new Exception("Unexpected");
			}
		}
	}
}