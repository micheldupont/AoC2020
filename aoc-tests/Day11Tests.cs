using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day11Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

			var test = new Day11().Run(input);

			Assert.Equal(37, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day11().Run(TestInput.Day11);

			Assert.Equal(2273, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

			var test = new Day11().Run2(input);

			Assert.Equal(26, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day11().Run2(TestInput.Day11);

			Assert.Equal(2064, test);
		}
	}
}