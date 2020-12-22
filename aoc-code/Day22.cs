using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Day22
	{
		public int Run(string input)
		{
			var playerInputs = input.Split("Player 2:");

			var player1Inputs = playerInputs[0].Replace("Player 1:", "")
				.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

			var player2Inputs = playerInputs[1]
				.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

			RunGame(ref player1Inputs, ref player2Inputs);

			var multiplierBase = (player1Inputs.Count > 0 ? player1Inputs : player2Inputs).Count;

			var score = 0;
			for (var i = 0; i < (player1Inputs.Count > 0 ? player1Inputs : player2Inputs).Count; i++)
			{
				var card = (player1Inputs.Count > 0 ? player1Inputs : player2Inputs)[i];
				score += (multiplierBase - i) * card;
			}

			return score;
		}

		public int Run2(string input)
		{
			var playerInputs = input.Split("Player 2:");

			var player1Inputs = playerInputs[0].Replace("Player 1:", "")
				.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

			var player2Inputs = playerInputs[1]
				.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

			var player1HasWon = RunGame2(ref player1Inputs, ref player2Inputs);

			var multiplierBase = (player1HasWon ? player1Inputs : player2Inputs).Count;

			var score = 0;
			for (var i = 0; i < (player1HasWon ? player1Inputs : player2Inputs).Count; i++)
			{
				var card = (player1HasWon ? player1Inputs : player2Inputs)[i];
				score += (multiplierBase - i) * card;
			}

			return score;
		}

		private void RunGame(ref List<int> player1Inputs, ref List<int> player2Inputs)
		{
			while (player1Inputs.Count != 0 && player2Inputs.Count != 0)
			{
				var player1Play = player1Inputs[0];
				player1Inputs.RemoveAt(0);

				var player2Play = player2Inputs[0];
				player2Inputs.RemoveAt(0);

				if (player1Play > player2Play)
				{
					player1Inputs.Add(player1Play);
					player1Inputs.Add(player2Play);
				}
				else
				{
					player2Inputs.Add(player2Play);
					player2Inputs.Add(player1Play);
				}
			}
		}

		private bool RunGame2(ref List<int> player1Inputs, ref List<int> player2Inputs)
		{
			var previousDeck1s = new List<string>();
			var previousDeck2s = new List<string>();

			while (player1Inputs.Count != 0 && player2Inputs.Count != 0)
			{
				var currentDeck1 = string.Join(",", player1Inputs);
				var currentDeck2 = string.Join(",", player2Inputs);

				//anti infinite loop rule
				if (previousDeck1s.Contains(currentDeck1) || previousDeck2s.Contains(currentDeck2))
				{
					return true;
				}

				previousDeck1s.Add(currentDeck1);
				previousDeck2s.Add(currentDeck2);

				var player1Play = player1Inputs[0];
				player1Inputs.RemoveAt(0);

				var player2Play = player2Inputs[0];
				player2Inputs.RemoveAt(0);

				//recursion rule/check
				var player1CanRecurse = player1Inputs.Count >= player1Play;
				var player2CanRecurse = player2Inputs.Count >= player2Play;

				if (player1CanRecurse && player2CanRecurse)
				{
					var player1RecurseInputs = player1Inputs.Take(player1Play).ToList();
					var player2RecurseInputs = player2Inputs.Take(player2Play).ToList();
					var player1WonRecurse = RunGame2(ref player1RecurseInputs, ref player2RecurseInputs);

					if (player1WonRecurse)
					{
						player1Inputs.Add(player1Play);
						player1Inputs.Add(player2Play);
					}
					else
					{
						player2Inputs.Add(player2Play);
						player2Inputs.Add(player1Play);
					}

					continue;
				}

				if (player1Play > player2Play)
				{
					player1Inputs.Add(player1Play);
					player1Inputs.Add(player2Play);
				}
				else
				{
					player2Inputs.Add(player2Play);
					player2Inputs.Add(player1Play);
				}
			}

			return player1Inputs.Count > 0;
		}
	}
}