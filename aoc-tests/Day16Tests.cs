using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day16Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

			var test = new Day16().Run(input);

			Assert.Equal(71, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day16().Run(TestInput.Day16);

			Assert.Equal(27870, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"class: 0-1 or 4-19
departure row: 0-5 or 8-19
departure seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
3,9,18
15,1,5
5,14,9";

			var test = new Day16().Run2(input);

			Assert.Equal((ulong) 11 * 13, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day16().Run2(TestInput.Day16);

			Assert.Equal((ulong) 3173135507987, test);
		}
	}
}