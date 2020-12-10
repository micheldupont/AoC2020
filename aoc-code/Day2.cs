using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace aoc_code
{
	public class PwPolicy
	{
		public int AtLeast { get; set; }
		public int AtMost { get; set; }
		public int TargetChar { get; set; }

		public char[] Pw { get; set; }
	}

	public class PwPolicy2
	{
		public int IndexA { get; set; }
		public int IndexB { get; set; }
		public int TargetChar { get; set; }

		public char[] Pw { get; set; }
	}

	public class Day2
	{
		private readonly Regex _knownFormat = new Regex("^([0-9]*)-([0-9]*) ([a-z]): ([a-z]*)$");

		public int Run(string inputStr)
		{
			var inputArr = new List<PwPolicy>();

			var inputs = inputStr.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
			foreach (var i in inputs)
			{
				var p = _knownFormat.Split(i);

				inputArr.Add(new PwPolicy
				{
					AtLeast = int.Parse(p[1]),
					AtMost = int.Parse(p[2]),
					TargetChar = p[3][0],
					Pw = p[4].ToCharArray()
				});
			}

			var valid = 0;

			foreach (var pw in inputArr)
			{
				var c = pw.TargetChar;
				var cCount = pw.Pw.Count(i => i == c);
				if (cCount >= pw.AtLeast && cCount <= pw.AtMost) valid += 1;
			}


			return valid;
		}

		public int Run2(string inputStr)
		{
			var inputArr = new List<PwPolicy2>();

			var inputs = inputStr.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
			foreach (var i in inputs)
			{
				var p = _knownFormat.Split(i);

				inputArr.Add(new PwPolicy2
				{
					IndexA = int.Parse(p[1]),
					IndexB = int.Parse(p[2]),
					TargetChar = p[3][0],
					Pw = p[4].ToCharArray()
				});
			}

			var valid = 0;

			foreach (var pw in inputArr)
			{
				var c = pw.TargetChar;

				var aOk = pw.Pw[pw.IndexA - 1] == c;
				var bOk = pw.Pw[pw.IndexB - 1] == c;

				if (aOk && !bOk || !aOk && bOk) valid += 1;
			}

			return valid;
		}
	}
}