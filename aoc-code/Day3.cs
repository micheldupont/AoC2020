using System;

namespace aoc_code
{
	public class Day3
	{
		public int Run(string input, int slopeRight, int slopeDown)
		{
			var lines = input.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
			var lineWidth = lines[0].Length;
			var lineCount = lines.Length;

			var field = new char[lineWidth, lineCount];

			for (var y = 0; y < lineCount; y++)
			{
				var lineChars = lines[y].ToCharArray();

				for (var x = 0; x < lineWidth; x++)
				{
					var lc = lineChars[x];
					field[x, y] = lc;
				}
			}

			var posX = 0;
			var posY = 0;
			var treeHits = 0;

			while (posY < lineCount)
			{
				if (field[posX, posY] == '#') treeHits++;

				posX = posX + slopeRight;
				posY = posY + slopeDown;

				if (posX > lineWidth - 1) //overflow to the right : repeat
					posX = posX % lineWidth;
			}

			return treeHits;
		}

		public long Run2(string input)
		{
			long a = Run(input, 1, 1);
			long b = Run(input, 3, 1);
			long c = Run(input, 5, 1);
			long d = Run(input, 7, 1);
			long e = Run(input, 1, 2);

			return a * b * c * d * e;
		}
	}
}