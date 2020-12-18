using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day17Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @".#.
..#
###";

			var test = new Day17().Run(input);

			Assert.Equal(112, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day17().Run(TestInput.Day17);

			Assert.Equal(324, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @".#.
..#
###";

			var test = new Day17().Run2(input);

			Assert.Equal(848, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day17().Run2(TestInput.Day17);

			Assert.Equal(1836, test);
		}
	}
}