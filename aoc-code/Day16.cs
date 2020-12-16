using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day16
	{
		public int Run(string input)
		{
			var data = ParseData(input);

			var invalidValues = new List<int>();

			foreach (var ticket in data.NearbyTickets)
			{
				foreach (var val in ticket)
				{
					if (data.Fields.Any(f => f.IsValueValid(val)))
					{
					}
					else
					{
						invalidValues.Add(val);
					}
				}
			}

			return invalidValues.Sum();
		}

		public ulong Run2(string input)
		{
			var data = ParseData(input);
			RemoveInvalidTickets(data);

			var ticketPositionCount = data.MyTicket.Count;
			var validFieldsForPosition = new List<Tuple<int, List<string>>>();

			// list all possible fields per position
			for (var i = 0; i < ticketPositionCount; i++)
			{
				var fields = data.Fields.Select(f => f.Name).ToList();

				foreach (var ticket in data.NearbyTickets)
				{
					var valueForPosition = ticket[i];
					var matchingFields = data.Fields.Where(f => f.IsValueValid(valueForPosition)).Select(f => f.Name)
						.ToList();

					fields = fields.Intersect(matchingFields).ToList();
				}

				validFieldsForPosition.Add(new Tuple<int, List<string>>(i, fields));
			}

			// loop:
			// find the position with only 1 field match
			//		record it,
			//		remove it,
			//		remove the field from all other positions
			//		repeat
			var mappedFields = new string[data.Fields.Count];

			while (validFieldsForPosition.Count > 0)
			{
				var fieldWithOnlyOneValid = validFieldsForPosition.First(v => v.Item2.Count == 1);

				validFieldsForPosition.Remove(fieldWithOnlyOneValid);
				var fieldName = fieldWithOnlyOneValid.Item2.First();
				mappedFields[fieldWithOnlyOneValid.Item1] = fieldName;

				validFieldsForPosition.ForEach(v => v.Item2.Remove(fieldName));
			}

			// final result
			ulong checksum = 1;
			for (var index = 0; index < mappedFields.Length; index++)
			{
				var mappedField = mappedFields[index];
				if (mappedField.StartsWith("departure"))
				{
					checksum = checksum * (ulong) data.MyTicket[index];
				}
			}

			return checksum;
		}

		private static void RemoveInvalidTickets(Day16Data data)
		{
			var invalidTickets = new List<List<int>>();

			foreach (var ticket in data.NearbyTickets)
			{
				foreach (var val in ticket)
				{
					if (data.Fields.Any(f => f.IsValueValid(val)))
					{
					}
					else
					{
						invalidTickets.Add(ticket);
					}
				}
			}

			foreach (var invalidTicket in invalidTickets)
			{
				data.NearbyTickets.Remove(invalidTicket);
			}
		}

		private Day16Data ParseData(string input)
		{
			var fields = new List<FieldDefinition>();
			var nearbyTickets = new List<List<int>>();

			var lines = input.Split("\r\n");

			var i = 0;

			// first part : field definitions
			var line = lines[i];
			while (line.Length != 0)
			{
				var parts = line.Split(": ");
				var fieldName = parts[0];
				var ranges = parts[1].Split(" or ");
				var rangeA = ranges[0].Split("-").Select(int.Parse).ToArray();
				var rangeB = ranges[1].Split("-").Select(int.Parse).ToArray();

				fields.Add(new FieldDefinition(fieldName, rangeA[0], rangeA[1], rangeB[0], rangeB[1]));
				i++;
				line = lines[i];
			}

			// 2nd part : my ticket
			i += 2; // skip "your ticket"
			line = lines[i];
			var myTicket = line.Split(",").Select(int.Parse).ToList();

			// 3rd part : other tickets
			i += 3; // skip "nearby ticket"
			while (i < lines.Length)
			{
				line = lines[i];
				nearbyTickets.Add(line.Split(",").Select(int.Parse).ToList());

				i++;
			}

			return new Day16Data
			{
				Fields = fields,
				MyTicket = myTicket,
				NearbyTickets = nearbyTickets
			};
		}
	}

	public class Day16Data
	{
		public List<FieldDefinition> Fields { get; set; }
		public List<int> MyTicket { get; set; }
		public List<List<int>> NearbyTickets { get; set; }
	}

	public class FieldDefinition
	{
		public FieldDefinition(string name, int rangeAMin, int rangeAMax, int rangeBMin, int rangeBMax)
		{
			Name = name;
			RangeAMin = rangeAMin;
			RangeAMax = rangeAMax;
			RangeBMin = rangeBMin;
			RangeBMax = rangeBMax;
		}

		public string Name { get; set; }

		public int RangeAMin { get; set; }
		public int RangeAMax { get; set; }

		public int RangeBMin { get; set; }
		public int RangeBMax { get; set; }

		public bool IsValueValid(int value) =>
			value >= RangeAMin && value <= RangeAMax || value >= RangeBMin && value <= RangeBMax;
	}
}