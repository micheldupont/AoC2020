using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Tile
	{
		public Tile(int id, char[,] tileData)
		{
			Id = id;
			TileData = tileData;

			Checksums = new List<Tuple<string, int>>
			{
				new Tuple<string, int>("T", ChecksumH(0)),
				new Tuple<string, int>("B", ChecksumH(9)),
				new Tuple<string, int>("L", ChecksumV(0)),
				new Tuple<string, int>("R", ChecksumV(9)),
				new Tuple<string, int>("Ti", ChecksumH(0, true)),
				new Tuple<string, int>("Bi", ChecksumH(9, true)),
				new Tuple<string, int>("Li", ChecksumV(0, true)),
				new Tuple<string, int>("Ri", ChecksumV(9, true))
			};
		}

		public int Id { get; }
		public char[,] TileData { get; }
		public List<Tuple<string, int>> Checksums { get; }
		public List<Tuple<string, int, int, string, int>> Matches { get; set; }

		private int ChecksumH(int index, bool flipped = false)
		{
			var chars = new char[10];
			for (var i = 0; i < 10; i++)
			{
				chars[i] = TileData[index, i];
			}

			var asString = "";

			if (flipped)
			{
				asString = new string(chars.Reverse().ToArray()).Replace('.', '0').Replace('#', '1');
			}
			else
			{
				asString = new string(chars).Replace('.', '0').Replace('#', '1');
			}

			var asInt = Convert.ToInt32(asString, 2);

			return asInt;
		}

		private int ChecksumV(int index, bool flipped = false)
		{
			var chars = new char[10];
			for (var j = 0; j < 10; j++)
			{
				chars[j] = TileData[j, index];
			}

			var asString = "";

			if (flipped)
			{
				asString = new string(chars.Reverse().ToArray()).Replace('.', '0').Replace('#', '1');
			}
			else
			{
				asString = new string(chars).Replace('.', '0').Replace('#', '1');
			}

			var asInt = Convert.ToInt32(asString, 2);

			return asInt;
		}
	}

	public class Day20
	{
		public decimal Run(string input)
		{
			var tiles = new List<Tile>();

			var lines = input.Split("\r\n").ToList();

			for (var index = 0; index < lines.Count; index++)
			{
				var line = lines[index];

				var id = int.Parse(line.Replace("Tile ", "").Replace(":", ""));

				var tileData = new char[10, 10];
				var y = 0;
				for (var i = 1; i <= 10; i++)
				{
					var tileLine = lines[index + i].ToCharArray();

					for (var x = 0; x < tileLine.Length; x++)
					{
						var c = tileLine[x];

						tileData[x, y] = c;
					}

					y++;
				}

				index += 11;

				tiles.Add(new Tile(id, tileData));
			}

			foreach (var tile in tiles)
			{
				var matches = new List<Tuple<string, int, int, string, int>>();
				foreach (var cs in tile.Checksums.Select(c => c))
				{
					foreach (var otherTile in tiles.Where(t => t.Id != tile.Id))
					{
						var match = otherTile.Checksums.Find(ocs => ocs.Item2 == cs.Item2);

						if (match != null)
						{
							matches.Add(new Tuple<string, int, int, string, int>(cs.Item1, cs.Item2, otherTile.Id,
								match.Item1, match.Item2));
						}
					}
				}

				tile.Matches = matches;
			}

			// corners only have matches on 2 sides (so 4 cs total because of flipped)
			var corners = tiles.Where(t => t.Matches.Count == 4);

			decimal result = 1;
			foreach (var corner in corners)
			{
				result = result * corner.Id;
			}

			return result;
		}

		public decimal Run2(string input)
		{
			var tiles = new List<Tile>();

			var lines = input.Split("\r\n").ToList();

			for (var index = 0; index < lines.Count; index++)
			{
				var line = lines[index];

				var id = int.Parse(line.Replace("Tile ", "").Replace(":", ""));

				var tileData = new char[10, 10];
				var y = 0;
				for (var i = 1; i <= 10; i++)
				{
					var tileLine = lines[index + i].ToCharArray();

					for (var x = 0; x < tileLine.Length; x++)
					{
						var c = tileLine[x];

						tileData[x, y] = c;
					}

					y++;
				}

				index += 11;

				tiles.Add(new Tile(id, tileData));
			}

			foreach (var tile in tiles)
			{
				var matches = new List<Tuple<string, int, int, string, int>>();
				foreach (var cs in tile.Checksums.Select(c => c))
				{
					foreach (var otherTile in tiles.Where(t => t.Id != tile.Id))
					{
						var match = otherTile.Checksums.Find(ocs => ocs.Item2 == cs.Item2);

						if (match != null)
						{
							matches.Add(new Tuple<string, int, int, string, int>(cs.Item1, cs.Item2, otherTile.Id,
								match.Item1, match.Item2));
						}
					}
				}

				tile.Matches = matches;
			}

			// corners only have matches on 2 sides (so 4 cs total because of flipped)
			var corners = tiles.Where(t => t.Matches.Count == 4);

			decimal result = 1;
			foreach (var corner in corners)
			{
				result = result * corner.Id;
			}

			return result;
		}
	}
}