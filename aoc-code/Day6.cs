using System.Collections.Generic;
using System.Linq;

namespace aoc_code
{
	public class Group
	{
		public List<string> PeopleAnswers { get; set; }

		public char[] GetUniqueYes()
		{
			var dict = CompileAnswers();

			return dict.Keys.ToArray();
		}

		public char[] GetCommonYes()
		{
			var dict = CompileAnswers();
			var peopleCount = PeopleAnswers.Count();

			var commons = new List<char>();

			foreach (var key in dict.Keys)
				if (dict[key] == peopleCount)
					commons.Add(key);

			return commons.ToArray();
		}

		private Dictionary<char, int> CompileAnswers()
		{
			var dict = new Dictionary<char, int>();
			foreach (var answer in PeopleAnswers)
			{
				var yeses = answer.ToCharArray();

				foreach (var yes in yeses)
					if (dict.ContainsKey(yes))
						dict[yes] = dict[yes] + 1;
					else
						dict.Add(yes, 1);
			}

			return dict;
		}
	}

	public class Day6
	{
		public int Run(string input)
		{
			var groupList = ParseGroupList(input);
			var sumOfYes = groupList.Sum(g => g.GetUniqueYes().Length);

			return sumOfYes;
		}

		public int Run2(string input)
		{
			var groupList = ParseGroupList(input);
			var sumOfYes = groupList.Sum(g => g.GetCommonYes().Length);

			return sumOfYes;
		}

		private List<Group> ParseGroupList(string input)
		{
			var lines = input.Split("\r\n");

			var lineIndex = 0;

			var groupList = new List<Group>();
			var groupLines = new List<string>();
			while (lineIndex < lines.Length)
			{
				var currentLine = lines[lineIndex];
				if (currentLine.Length > 0)
				{
					groupLines.Add(currentLine);
				}
				else
				{
					groupList.Add(new Group {PeopleAnswers = groupLines});
					groupLines = new List<string>();
				}

				lineIndex++;
			}

			if (groupLines.Count > 0) groupList.Add(new Group {PeopleAnswers = groupLines});

			return groupList;
		}
	}
}