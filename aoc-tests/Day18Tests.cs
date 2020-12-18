using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day18Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"1 + 2 * 3 + 4 * 5 + 6";

			var test = new Day18().Run(input);

			Assert.Equal(71, test);
		}

		[Fact]
		public void Run1ExampleB()
		{
			var input = @"1 + (2 * 3) + (4 * (5 + 6))";

			var test = new Day18().Run(input);

			Assert.Equal(51, test);
		}

		[Fact]
		public void Run1ExampleC()
		{
			var input = @"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

			var test = new Day18().Run(input);

			Assert.Equal(13632, test);
		}

		[Fact]
		public void Run1ExampleD()
		{
			var input = @"2 * 3 + (4 * 5)
5 + (8 * 3 + 9 + 3 * 4 * 3)
5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

			var test = new Day18().Run(input);

			Assert.Equal(26 + 437 + 12240 + 13632, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day18().Run(TestInput.Day18);

			Assert.Equal(30753705453324, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"1 + 2 * 3 + 4 * 5 + 6";

			var test = new Day18().Run2(input);

			Assert.Equal(231, test);
		}

		[Fact]
		public void Run2ExampleB()
		{
			var input = @"1 + (2 * 3) + (4 * (5 + 6))";

			var test = new Day18().Run2(input);

			Assert.Equal(51, test);
		}

		[Fact]
		public void Run2ExampleC()
		{
			var input = @"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

			var test = new Day18().Run2(input);

			Assert.Equal(23340, test);
		}

		[Fact]
		public void Run2ExampleD()
		{
			var input = @"2 * 3 + (4 * 5)
5 + (8 * 3 + 9 + 3 * 4 * 3)
5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

			var test = new Day18().Run2(input);

			Assert.Equal(46 + 1445 + 669060 + 23340, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day18().Run2(TestInput.Day18);

			Assert.Equal(244817530095503, test);
		}
	}
}