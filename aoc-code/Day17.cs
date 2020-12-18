using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day17
	{
		public int Run(string input)
		{
			var lines = input.Split("\r\n");

			var coords = new Dictionary<Tuple<int, int, int>, bool>();

			var y = 0;
			foreach (var line in lines)
			{
				var x = 0;
				foreach (var c in line)
				{
					var active = c == '#';
					coords.Add(new Tuple<int, int, int>(x, y, 0), active);
					x++;
				}

				y++;
			}

			var maxX = lines[0].Length;
			var maxY = lines.Length;
			var maxZ = 1;
			var minX = -1;
			var minY = -1;
			var minZ = -1;

			for (var i = 0; i < 6; i++)
			{
				var newState = new Dictionary<Tuple<int, int, int>, bool>();

				for (var zi = minZ; zi <= maxZ; zi++)
				{
					for (var yi = minY; yi <= maxY; yi++)
					{
						for (var xi = minX; xi <= maxX; xi++)
						{
							var currentCoord = new Tuple<int, int, int>(xi, yi, zi);

							bool isActive;
							coords.TryGetValue(currentCoord, out isActive);

							var count = ActiveNeighbor(currentCoord, ref coords);

							if (isActive)
							{
								if (count != 2 && count != 3)
								{
									isActive = false;
								}
							}
							else
							{
								if (count == 3)
								{
									isActive = true;
								}
							}

							newState.Add(currentCoord, isActive);
						}
					}
				}

				coords = newState;
				maxX++;
				maxY++;
				maxZ++;
				minX--;
				minY--;
				minZ--;
			}

			var activeCubes = coords.Values.Count(isActive => isActive);
			return activeCubes;
		}

		public int Run2(string input)
		{
			var lines = input.Split("\r\n");

			var coords = new Dictionary<Tuple<int, int, int, int>, bool>();

			var y = 0;
			foreach (var line in lines)
			{
				var x = 0;
				foreach (var c in line)
				{
					var active = c == '#';
					coords.Add(new Tuple<int, int, int, int>(x, y, 0, 0), active);
					x++;
				}

				y++;
			}

			var maxX = lines[0].Length;
			var maxY = lines.Length;
			var maxZ = 1;
			var maxW = 1;
			var minX = -1;
			var minY = -1;
			var minZ = -1;
			var minW = -1;

			for (var i = 0; i < 6; i++)
			{
				var newState = new Dictionary<Tuple<int, int, int, int>, bool>();

				for (var wi = minW; wi <= maxW; wi++)
				{
					for (var zi = minZ; zi <= maxZ; zi++)
					{
						for (var yi = minY; yi <= maxY; yi++)
						{
							for (var xi = minX; xi <= maxX; xi++)
							{
								var currentCoord = new Tuple<int, int, int, int>(xi, yi, zi, wi);

								bool isActive;
								coords.TryGetValue(currentCoord, out isActive);

								var count = ActiveNeighbor2(currentCoord, ref coords);

								if (isActive)
								{
									if (count != 2 && count != 3)
									{
										isActive = false;
									}
								}
								else
								{
									if (count == 3)
									{
										isActive = true;
									}
								}

								newState.Add(currentCoord, isActive);
							}
						}
					}
				}

				coords = newState;
				maxX++;
				maxY++;
				maxZ++;
				maxW++;
				minX--;
				minY--;
				minZ--;
				minW--;
			}

			var activeCubes = coords.Values.Count(isActive => isActive);
			return activeCubes;
		}

		private int ActiveNeighbor(Tuple<int, int, int> currentCoord, ref Dictionary<Tuple<int, int, int>, bool> coords)
		{
			var count = 0;
			for (var z = currentCoord.Item3 - 1; z <= currentCoord.Item3 + 1; z++)
			{
				for (var y = currentCoord.Item2 - 1; y <= currentCoord.Item2 + 1; y++)
				{
					for (var x = currentCoord.Item1 - 1; x <= currentCoord.Item1 + 1; x++)
					{
						if (x == currentCoord.Item1 && y == currentCoord.Item2 && z == currentCoord.Item3) //skip self
						{
							continue;
						}

						var testingCoord = new Tuple<int, int, int>(x, y, z);
						bool isActive;
						coords.TryGetValue(testingCoord, out isActive);

						if (isActive)
						{
							count++;
						}
					}
				}
			}

			return count;
		}

		private int ActiveNeighbor2(Tuple<int, int, int, int> currentCoord,
			ref Dictionary<Tuple<int, int, int, int>, bool> coords)
		{
			var count = 0;
			for (var w = currentCoord.Item4 - 1; w <= currentCoord.Item4 + 1; w++)
			{
				for (var z = currentCoord.Item3 - 1; z <= currentCoord.Item3 + 1; z++)
				{
					for (var y = currentCoord.Item2 - 1; y <= currentCoord.Item2 + 1; y++)
					{
						for (var x = currentCoord.Item1 - 1; x <= currentCoord.Item1 + 1; x++)
						{
							if (x == currentCoord.Item1 && y == currentCoord.Item2 &&
							    z == currentCoord.Item3 && w == currentCoord.Item4) //skip self
							{
								continue;
							}

							var testingCoord = new Tuple<int, int, int, int>(x, y, z, w);
							bool isActive;
							coords.TryGetValue(testingCoord, out isActive);

							if (isActive)
							{
								count++;
							}
						}
					}
				}
			}

			return count;
		}
	}
}