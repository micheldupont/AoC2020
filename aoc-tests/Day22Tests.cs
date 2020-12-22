using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day22Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

			var test = new Day22().Run(input);

			Assert.Equal(306, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day22().Run(TestInput.Day22);

			Assert.Equal(34566, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

			var test = new Day22().Run2(input);

			Assert.Equal(291, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day22().Run2(TestInput.Day22);

			Assert.Equal(31854, test);
		}
	}
}