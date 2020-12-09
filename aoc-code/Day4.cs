using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace aoc_code
{
	public class Passport
	{
		private readonly string[] _expectedKeys = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" /*, "cid"*/};

		public List<Tuple<string, string>> Data { get; } = new List<Tuple<string, string>>();

		public bool IsValid(bool simple = false)
		{
			if (!AllDataThere()) return false;

			if (simple) return true;

			foreach (var k in _expectedKeys)
			{
				var value = Data.Find(t => t.Item1 == k);

				if (value == null)
					throw new Exception("something went wrong...");

				switch (k)
				{
					case "byr":
						if (!Validbyr(value.Item2)) return false;
						break;
					case "iyr":
						if (!Validiyr(value.Item2)) return false;
						break;
					case "eyr":
						if (!Valideyr(value.Item2)) return false;
						break;
					case "hgt":
						if (!Validhgt(value.Item2)) return false;
						break;
					case "hcl":
						if (!Validhcl(value.Item2)) return false;
						break;
					case "ecl":
						if (!Validecl(value.Item2)) return false;
						break;
					case "pid":
						if (!Validpid(value.Item2)) return false;
						break;
				}
			}


			return true;
		}

		private bool AllDataThere()
		{
			foreach (var k in _expectedKeys)
				if (Data.Find(t => t.Item1 == k) == null)
					return false;
			return true;
		}

		private bool Validbyr(string value)
		{
			if (!int.TryParse(value, out var asInt)) return false;
			if (asInt <= 2002 && asInt >= 1920) return true;
			return false;
		}

		private bool Validiyr(string value)
		{
			if (!int.TryParse(value, out var asInt)) return false;
			if (asInt <= 2020 && asInt >= 2010) return true;
			return false;
		}

		private bool Valideyr(string value)
		{
			if (!int.TryParse(value, out var asInt)) return false;
			if (asInt <= 2030 && asInt >= 2020) return true;
			return false;
		}

		private bool Validhgt(string value)
		{
			var testRegEx = new Regex("^(\\d{1,})(in|cm)\\s?$");
			if (testRegEx.IsMatch(value))
			{
				var parts = testRegEx.Split(value);
				var num = int.Parse(parts[1]);
				var unit = parts[2];

				if (unit == "cm")
				{
					if (num >= 150 && num <= 193) return true;
				}
				else if (unit == "in")
				{
					if (num >= 59 && num <= 76) return true;
				}
			}

			return false;
		}

		private bool Validhcl(string value)
		{
			var testRegEx = new Regex("^#[\\d,\\w]{6}\\s?$");
			if (testRegEx.IsMatch(value)) return true;
			return false;
		}

		private bool Validecl(string value)
		{
			var testRegEx = new Regex("^amb|blu|brn|gry|grn|hzl|oth\\s?$");
			if (testRegEx.IsMatch(value)) return true;
			return false;
		}

		private bool Validpid(string value)
		{
			var testRegEx = new Regex("^[\\d]{9}\\s?$");
			if (testRegEx.IsMatch(value)) return true;
			return false;
		}
	}

	public class Day4
	{
		public int Run(string input)
		{
			var passports = Parse(input);
			var validCount = 0;

			foreach (var p in passports)
				if (p.IsValid(true))
					validCount += 1;

			return validCount;
		}

		public int Run2(string input)
		{
			var passports = Parse(input);
			var validCount = 0;

			foreach (var p in passports)
				if (p.IsValid())
					validCount += 1;

			return validCount;
		}

		private List<Passport> Parse(string input)
		{
			var passports = new List<Passport>();

			var parts = input.Split("\r\n");
			var index = 0;

			var lines = new List<string>();
			while (index < parts.Length)
			{
				var line = parts[index];
				if (line.Length == 0)
				{
					var pp = new Passport();
					foreach (var l in lines)
					{
						var codes = l.Split(' ', StringSplitOptions.RemoveEmptyEntries);
						foreach (var c in codes)
						{
							var kv = c.Split(':');
							pp.Data.Add(new Tuple<string, string>(kv[0], kv[1]));
						}
					}

					passports.Add(pp);
					lines.Clear();
				}
				else
				{
					lines.Add(line);
				}

				index++;
			}

			if (lines.Count != 0)
			{
				var pp = new Passport();
				foreach (var l in lines)
				{
					var codes = l.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					foreach (var c in codes)
					{
						var kv = c.Split(':');
						pp.Data.Add(new Tuple<string, string>(kv[0], kv[1]));
					}
				}

				passports.Add(pp);
				lines.Clear();
			}

			return passports;
		}
	}
}