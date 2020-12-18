using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day18
	{
		public decimal Run(string input)
		{
			var lines = input.Split("\r\n");

			var results = new List<ulong>();

			foreach (var line in lines)
			{
				var inputs = line.Replace(" ", "").ToCharArray();

				var res = EvalExpression(inputs);
				results.Add(res);
			}

			return results.Sum(x => (decimal) x);
		}

		public decimal Run2(string input)
		{
			var lines = input.Split("\r\n");

			var results = new List<ulong>();

			foreach (var line in lines)
			{
				var inputs = line.Replace(" ", "").ToCharArray();
				inputs = PatchInputsForNewMath(inputs);
				var res = EvalExpression(inputs);
				results.Add(res);
			}

			return results.Sum(x => (decimal) x);
		}

		private char[] PatchInputsForNewMath(char[] inputs)
		{
			var inputAsList = inputs.ToList();
			var plusIndex = inputAsList.FindIndex(c => c == '+');

			while (plusIndex > 0)
			{
				//     1 + 3
				var insertBeforeIndex = plusIndex - 1;
				if (inputAsList[insertBeforeIndex] == ')')
				{
					insertBeforeIndex = FindOpeningIndex(inputAsList.ToArray(), insertBeforeIndex);
				}

				var insertAfterIndex = plusIndex + 2;
				if (inputAsList[plusIndex + 1] == '(')
				{
					insertAfterIndex = FindClosingIndex(inputAsList.ToArray(), plusIndex + 1);
				}

				inputAsList.Insert(insertAfterIndex, ')');
				inputAsList.Insert(insertBeforeIndex, '(');

				plusIndex = inputAsList.FindIndex(plusIndex + 2,
					c => c == '+'); //+1 to not stay in place, +1 because we just added something before
			}

			return inputAsList.ToArray();
		}

		private ulong EvalExpression(char[] inputs)
		{
			ulong currentValue = 1;
			var currentOperator = '*';

			var index = 0;
			while (index < inputs.Length)
			{
				var c = inputs[index];
				switch (c)
				{
					case '(':
						var closingIndex = FindClosingIndex(inputs, index);
						var subArray = inputs.Skip(index + 1).Take(closingIndex - index - 1).ToArray();
						var subValue = EvalExpression(subArray);
						index = closingIndex;

						if (currentOperator == '*')
						{
							currentValue = currentValue * subValue;
						}
						else // +
						{
							currentValue = currentValue + subValue;
						}

						break;
					case '+':
					case '*':
						currentOperator = c;
						break;
					default: // 1,2,3,4,5,6,7,8,9
						var val = ulong.Parse(c.ToString());
						if (currentOperator == '*')
						{
							currentValue = currentValue * val;
						}
						else // +
						{
							currentValue = currentValue + val;
						}

						break;
				}

				index++;
			}

			return currentValue;
		}

		private int FindClosingIndex(char[] inputs, in int index)
		{
			var opened = 0;

			for (var i = index; i < inputs.Length; i++)
			{
				if (inputs[i] == '(')
				{
					opened++;
				}
				else
				{
					if (inputs[i] == ')')
					{
						opened--;
						if (opened == 0)
						{
							return i;
						}
					}
				}
			}

			return -1;
		}

		private int FindOpeningIndex(char[] inputs, in int index)
		{
			var opened = 0;

			for (var i = index; i >= 0; i--)
			{
				if (inputs[i] == ')')
				{
					opened++;
				}
				else
				{
					if (inputs[i] == '(')
					{
						opened--;
						if (opened == 0)
						{
							return i;
						}
					}
				}
			}

			return -1;
		}
	}
}