using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day9Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

			var test = new Day9().Run(input, 5);

			Assert.Equal(127, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day9().Run(TestInput.Day9, 25);

			Assert.Equal(530627549, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

			var test = new Day9().Run2(input, 5);

			Assert.Equal(62, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day9().Run2(TestInput.Day9, 25);

			Assert.Equal(77730285, test);
		}
	}
}