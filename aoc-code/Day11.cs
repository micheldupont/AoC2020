using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day11
	{
		public int Run(string input)
		{
			var grid = ParseGrid(input);

			var changed = true;
			while (changed)
			{
				changed = Mutate(ref grid);
			}

			var seatCount = grid.Cast<char>().Count(c => c == '#');
			return seatCount;
		}

		public int Run2(string input)
		{
			var grid = ParseGrid(input);

			var changed = true;
			while (changed)
			{
				changed = Mutate2(ref grid);
			}

			var seatCount = grid.Cast<char>().Count(c => c == '#');
			return seatCount;
		}

		private static char[,] ParseGrid(string input)
		{
			var lines = input.Split("\r\n");
			var height = lines.Length;
			var width = lines[0].Length;

			var grid = new char[width, height];

			for (var y = 0; y < lines.Length; y++)
			{
				var lineChars = lines[y].ToCharArray();

				for (var x = 0; x < lineChars.Length; x++)
				{
					var lineChar = lineChars[x];
					grid[x, y] = lineChar;
				}
			}

			return grid;
		}

		private bool Mutate(ref char[,] grid)
		{
			var changed = false;
			var xSize = grid.GetLength(0);
			var ySize = grid.GetLength(1);

			var gridCopy = (char[,]) grid.Clone();

			for (var y = 0; y < ySize; y++)
			{
				for (var x = 0; x < xSize; x++)
				{
					var old = gridCopy[x, y];

					var current = gridCopy[x, y];
					var neighbors = GenerateNeighborsList(x, y, xSize, ySize);
					var occupied = neighbors.Select(n => gridCopy[n.Item1, n.Item2]).Count(i => i == '#');

					switch (current)
					{
						case 'L' when occupied == 0:
							current = '#';
							break;
						case '#' when occupied >= 4:
							current = 'L';
							break;
					}

					grid[x, y] = current;

					if (current != old)
					{
						changed = true;
					}
				}
			}

			return changed;
		}

		private static List<Tuple<int, int>> GenerateNeighborsList(int x, int y, int xSize, int ySize)
		{
			var neighbors = new List<Tuple<int, int>>
			{
				new Tuple<int, int>(x - 1, y - 1),
				new Tuple<int, int>(x - 1, y),
				new Tuple<int, int>(x - 1, y + 1),
				new Tuple<int, int>(x, y - 1),
				new Tuple<int, int>(x, y + 1),
				new Tuple<int, int>(x + 1, y - 1),
				new Tuple<int, int>(x + 1, y),
				new Tuple<int, int>(x + 1, y + 1)
			};
			neighbors = neighbors.Where(n =>
				n.Item1 >= 0 &&
				n.Item2 >= 0 &&
				n.Item1 < xSize &&
				n.Item2 < ySize
			).ToList();
			return neighbors;
		}

		private bool Mutate2(ref char[,] grid)
		{
			var changed = false;
			var xSize = grid.GetLength(0);
			var ySize = grid.GetLength(1);

			var gridCopy = (char[,]) grid.Clone();

			for (var y = 0; y < ySize; y++)
			{
				for (var x = 0; x < xSize; x++)
				{
					var old = gridCopy[x, y];

					var current = gridCopy[x, y];
					var neighborsLos = GenerateNeighborsLOSList(x, y, xSize, ySize);
					var occupied = neighborsLos.Count(l => l
							.Select(n => gridCopy[n.Item1, n.Item2])
							.FirstOrDefault(c => c != '.') == '#'
					);

					switch (current)
					{
						case 'L' when occupied == 0:
							current = '#';
							break;
						case '#' when occupied >= 5:
							current = 'L';
							break;
					}

					grid[x, y] = current;

					if (current != old)
					{
						changed = true;
					}
				}
			}

			return changed;
		}

		private List<List<Tuple<int, int>>> GenerateNeighborsLOSList(int x, int y, int xSize, int ySize)
		{
			var list = new List<List<Tuple<int, int>>>();
			//N
			var n = new List<Tuple<int, int>>();
			for (var y2 = y - 1; y2 >= 0; y2--)
			{
				n.Add(new Tuple<int, int>(x, y2));
			}

			list.Add(n);
			//NE
			var ne = new List<Tuple<int, int>>();
			for (int x2 = x + 1, y2 = y - 1; x2 < xSize && y2 >= 0; x2++, y2--)
			{
				ne.Add(new Tuple<int, int>(x2, y2));
			}

			list.Add(ne);
			//E
			var e = new List<Tuple<int, int>>();
			for (var x2 = x + 1; x2 < xSize; x2++)
			{
				e.Add(new Tuple<int, int>(x2, y));
			}

			list.Add(e);
			//SE
			var se = new List<Tuple<int, int>>();
			for (int x2 = x + 1, y2 = y + 1; x2 < xSize && y2 < ySize; x2++, y2++)
			{
				se.Add(new Tuple<int, int>(x2, y2));
			}

			list.Add(se);
			//S
			var s = new List<Tuple<int, int>>();
			for (var y2 = y + 1; y2 < ySize; y2++)
			{
				s.Add(new Tuple<int, int>(x, y2));
			}

			list.Add(s);
			//SW
			var sw = new List<Tuple<int, int>>();
			for (int x2 = x - 1, y2 = y + 1; x2 >= 0 && y2 < ySize; x2--, y2++)
			{
				sw.Add(new Tuple<int, int>(x2, y2));
			}

			list.Add(sw);
			//W
			var w = new List<Tuple<int, int>>();
			for (var x2 = x - 1; x2 >= 0; x2--)
			{
				w.Add(new Tuple<int, int>(x2, y));
			}

			list.Add(w);
			//Nw
			var nw = new List<Tuple<int, int>>();
			for (int x2 = x - 1, y2 = y - 1; x2 >= 0 && y2 >= 0; x2--, y2--)
			{
				nw.Add(new Tuple<int, int>(x2, y2));
			}

			list.Add(nw);

			return list;
		}
	}
}