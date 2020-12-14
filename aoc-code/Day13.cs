using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day13
	{
		public int Run(string input)
		{
			var lines = input.Split("\r\n");
			var startTime = int.Parse(lines[0]);

			var buses = lines[1].Split(",").Where(c => c != "x").Select(int.Parse).ToList();

			var checkTime = startTime;

			while (true)
			{
				var foundBus = buses.Find(b => checkTime % b == 0);

				if (foundBus != 0)
				{
					var timeToWait = checkTime - startTime;

					return foundBus * timeToWait;
				}

				checkTime += 1;
			}
		}

		public ulong Run2(string input)
		{
			var lines = input.Split("\r\n");
			var buses = lines[1].Split(",").Select(c => c == "x" ? null : (ulong?) int.Parse(c)).ToList();


			var busesWithCheckTimeOffset = Enumerable.Range(0, buses.Count).Select(i => (ulong) i)
				.Zip(buses, (offset, bus) => new Tuple<ulong?, ulong>(bus, offset)).Where(t => t.Item1.HasValue)
				.OrderBy(bwo => bwo.Item1)
				.ToList();

			ulong time;
			if (busesWithCheckTimeOffset[0].Item2 > busesWithCheckTimeOffset[0].Item1.Value
			) // cannot start with negative time... especially when type is unsigned...
			{
				var ratio = busesWithCheckTimeOffset[0].Item2 / busesWithCheckTimeOffset[0].Item1.Value;
				time = busesWithCheckTimeOffset[0].Item1.Value * (ratio + 1) - busesWithCheckTimeOffset[0].Item2;
			}
			else
			{
				time = busesWithCheckTimeOffset[0].Item1.Value - busesWithCheckTimeOffset[0].Item2;
			}


			var step = busesWithCheckTimeOffset[0].Item1.Value;
			var index = 0;

			while (index < busesWithCheckTimeOffset.Count - 1)
			{
				var next = busesWithCheckTimeOffset[index + 1];

				var synced = false;
				while (!synced)
				{
					var nextTime = next.Item2 + time;

					if (nextTime % next.Item1.Value == 0)
					{
						step = step * next.Item1.Value;
						index += 1;
						synced = true;
					}
					else
					{
						time += step;
					}
				}
			}

			return time;
		}
	}
}