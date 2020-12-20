using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace aoc_code
{
	public class Day19
	{
		public int Run(string input)
		{
			var lines = input.Split("\r\n").ToList();

			var rules = ParseRules(lines);
			var messages = ParseMessages(lines);

			var compiledRules = Compile(rules, 0);

			var rulesAsRegEx = new Regex($"^{compiledRules}$");

			return messages.Count(rulesAsRegEx.IsMatch);
		}

		public int Run2(string input)
		{
			var lines = input.Split("\r\n").ToList();

			var rules = ParseRules(lines);
			var messages = ParseMessages(lines);

			PatchRule(rules, 8, "42 | 42 8");
			PatchRule(rules, 11, "42 31 | 42 11 31");

			var compiledRules = Compile(rules, 0);

			var rulesAsRegEx = new Regex($"^{compiledRules}$");

			return messages.Count(rulesAsRegEx.IsMatch);
		}

		private static void PatchRule(List<Tuple<int, string>> rules, int id, string rule)
		{
			var ruleIndex = rules.FindIndex(r => r.Item1 == id);
			var newRule = new Tuple<int, string>(id, rule);
			rules.RemoveAt(ruleIndex);
			rules.Insert(ruleIndex, newRule);
		}

		private static List<string> ParseMessages(List<string> lines)
		{
			var emptyLineIndex = lines.FindIndex(l => l == string.Empty);
			var messages = lines.Skip(emptyLineIndex + 1).ToList();
			return messages;
		}

		private static List<Tuple<int, string>> ParseRules(List<string> lines)
		{
			var emptyLineIndex = lines.FindIndex(l => l == string.Empty);

			var ruleLines = lines.Take(emptyLineIndex).ToList();
			var rules = new List<Tuple<int, string>>();

			foreach (var ruleLine in ruleLines)
			{
				var parts = ruleLine.Split(": ");
				var num = int.Parse(parts[0]);
				var matches = parts[1];

				rules.Add(new Tuple<int, string>(num, matches));
			}

			return rules;
		}


		private string Compile(List<Tuple<int, string>> rules, int startIndex, int recursionDepth = 0)
		{
			recursionDepth += 1;

			var rule = rules.Find(r => r.Item1 == startIndex);

			if (rule.Item2 == "\"a\"")
			{
				return "a";
			}

			if (rule.Item2 == "\"b\"")
			{
				return "b";
			}

			// part2: with new rules * and 11... this can go forever...
			// but messages are not that long so we can cut it short
			if (recursionDepth > 20)
			{
				return "x";
			}

			var parts = rule.Item2.Split(" ");
			var builder = new StringBuilder();

			foreach (var part in parts)
			{
				switch (part)
				{
					case "|":
						builder.Append("|");
						break;
					default:
						var index = int.Parse(part);
						builder.Append("(");
						builder.Append(Compile(rules, index, recursionDepth));
						builder.Append(")");
						break;
				}
			}

			return builder.ToString();
		}
	}
}