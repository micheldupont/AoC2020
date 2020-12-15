using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day14
	{
		public decimal Run(string input)
		{
			var lines = input.Split("\r\n");

			ulong orMask = 0;
			ulong andMask = 0;

			var mem = new Dictionary<int, ulong>();

			foreach (var line in lines)
			{
				if (line.StartsWith("mask")) //mask
				{
					var maskStr = line.Replace("mask = ", "");

					orMask = Convert.ToUInt64(maskStr.Replace("X", "0"), 2);
					andMask = Convert.ToUInt64(maskStr.Replace("X", "1"), 2);
				}
				else // mem op
				{
					var parts = line.Split("=", StringSplitOptions.RemoveEmptyEntries);

					var memIndex = int.Parse(parts[0].Replace("mem[", "").Replace("] ", ""));
					var value = ulong.Parse(parts[1].Trim());

					var maskedValue = (value | orMask) & andMask;

					mem[memIndex] = maskedValue;
				}
			}

			return (ulong) mem.Sum(x => (decimal) x.Value);
		}

		public ulong Run2(string input)
		{
			var lines = input.Split("\r\n");

			ulong orMask = 0;
			var maskStr = "";
			var floatingCount = 0;
			ulong permutationCount = 0;

			var mem = new Dictionary<ulong, ulong>();

			foreach (var line in lines)
			{
				if (line.StartsWith("mask")) //mask
				{
					maskStr = line.Replace("mask = ", "");

					orMask = Convert.ToUInt64(maskStr.Replace("X", "0"), 2);

					floatingCount = maskStr.Count(c => c == 'X');
					permutationCount = (ulong) Math.Pow(2, floatingCount);
				}
				else // mem op
				{
					var parts = line.Split("=", StringSplitOptions.RemoveEmptyEntries);

					var memIndex = ulong.Parse(parts[0].Replace("mem[", "").Replace("] ", ""));
					var value = ulong.Parse(parts[1].Trim());

					var partiallyMaskedMemIndex = memIndex | orMask;
					var partiallyMaskedMemIndexChars =
						Convert.ToString((long) partiallyMaskedMemIndex, 2)
							.PadLeft(maskStr.Length, '0')
							.ToCharArray();

					// at this point the mask - with 'X's (maskStr) and the partially maskedMemIndex (partiallyMaskedMemIndexChars) are of the same length
					// so positions of Xs in the mask are the same as the position of the digits to replace in the memIndex

					// to generate all the permutations of value for the Xs.. given that hey all are "bits", we can consider all those bits to be part of the same number
					// ex: 8 Xs means 8 bits, so 256 values (0 -> 255)
					// 
					// as we meet Xs in the mask, we replace the matching digit in the memIndex using the bits of the permutation (using int number converted to binary and string...
					// making sure the number is always padded to the correct length )
					for (ulong i = 0; i < permutationCount; i++)
					{
						var iAsChars = Convert.ToString((long) i, 2).PadLeft(floatingCount, '0').ToCharArray();
						var iIndex = 0;

						for (var maskIndex = 0; maskIndex < maskStr.Length; maskIndex++)
						{
							var c = maskStr[maskIndex];
							if (c == 'X')
							{
								partiallyMaskedMemIndexChars[maskIndex] = iAsChars[iIndex];
								iIndex += 1;
							}
						}

						var address = Convert.ToUInt64(new string(partiallyMaskedMemIndexChars), 2);
						mem[address] = value;
					}
				}
			}

			return (ulong) mem.Sum(x => (decimal) x.Value);
		}
	}
}