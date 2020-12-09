using System;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day7
	{
		public int Run(string input)
		{
			var bags = ParseBags(input);

			var goldBagCount = 0;

			foreach (var bag in bags)
				if (bag.Contains("shiny gold bag", ref bags))
					goldBagCount += 1;

			return goldBagCount;
		}

		public int Run2(string input)
		{
			var bags = ParseBags(input);
			var target = bags.Find(b => b.Name == "shiny gold bag");
			if (target == null)
				throw new Exception("something went wrong");

			return target.BagCount(ref bags);
		}

		private List<Bag> ParseBags(string input)
		{
			var bags = new List<Bag>();

			var lines = input.Split("\r\n");
			foreach (var line in lines)
			{
				var parts = line.Split(" contain ");
				var thisBag = parts[0].Replace("bags", "bag");

				var bag = new Bag {Name = thisBag};

				var containParts = parts[1].Split(',');
				foreach (var cp in containParts)
				{
					var cleaned = cp.Trim().Replace(".", "");
					var cleanedParts = cleaned.Split(" ", 2);

					if (cleanedParts[0] != "no")
					{
						var count = int.Parse(cleanedParts[0]);
						var thatBag = cleanedParts[1].Replace("bags", "bag");

						bag.Content.Add(thatBag, count);
					}
				}

				bags.Add(bag);
			}

			return bags;
		}
	}

	public class Bag
	{
		public string Name { get; set; }

		public Dictionary<string, int> Content { get; } = new Dictionary<string, int>();

		public bool Contains(string bagName, ref List<Bag> bagRefs)
		{
			foreach (var bag in Content.Keys)
			{
				if (bag == bagName) return true;

				var actualBag = bagRefs.Find(b => b.Name == bag);
				if (actualBag == null)
					throw new Exception("something went wrong");

				if (actualBag.Contains(bagName, ref bagRefs)) return true;
			}

			return false;
		}

		public int BagCount(ref List<Bag> bagRefs)
		{
			var count = 0;
			foreach (var bagName in Content.Keys)
			{
				var thisCount = Content[bagName];
				count += thisCount;

				var actualBag = bagRefs.Find(b => b.Name == bagName);
				if (actualBag == null)
					throw new Exception("something went wrong");

				count += thisCount * actualBag.BagCount(ref bagRefs);
			}

			return count;
		}
	}
}