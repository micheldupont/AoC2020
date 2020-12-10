using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day1Tests
	{
		[Fact]
		public void Run1Example()
		{
			var input = @"1721
979
366
299
675
1456";

			var test = new Day1().Run(input);
			Assert.Equal(514579, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day1().Run(TestInput.Day1);
			Assert.Equal(870331, test);
		}

		[Fact]
		public void Run2Example()
		{
			var input = @"1721
979
366
299
675
1456";

			var test = new Day1().Run2(input);
			Assert.Equal(241861950, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day1().Run2(TestInput.Day1);
			Assert.Equal(283025088, test);
		}
	}
}