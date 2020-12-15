using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day14Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";

			var test = new Day14().Run(input);

			Assert.Equal((ulong) 165, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day14().Run(TestInput.Day14);

			Assert.Equal((ulong) 5875750429995, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";

			var test = new Day14().Run2(input);

			Assert.Equal((ulong) 208, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day14().Run2(TestInput.Day14);

			Assert.Equal((ulong) 5272149590143, test);
		}
	}
}