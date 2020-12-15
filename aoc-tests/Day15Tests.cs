using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day15Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"0,3,6";

			var test = new Day15().Run(input);

			Assert.Equal(436, test);
		}

		[Fact]
		public void Run1ExampleB()
		{
			var input = @"1,3,2";

			var test = new Day15().Run(input);

			Assert.Equal(1, test);
		}

		[Fact]
		public void Run1ExampleC()
		{
			var input = @"2,1,3";

			var test = new Day15().Run(input);

			Assert.Equal(10, test);
		}

		[Fact]
		public void Run1ExampleD()
		{
			var input = @"1,2,3";

			var test = new Day15().Run(input);

			Assert.Equal(27, test);
		}

		[Fact]
		public void Run1ExampleE()
		{
			var input = @"2,3,1";

			var test = new Day15().Run(input);

			Assert.Equal(78, test);
		}

		[Fact]
		public void Run1ExampleF()
		{
			var input = @"3,2,1";

			var test = new Day15().Run(input);

			Assert.Equal(438, test);
		}

		[Fact]
		public void Run1ExampleG()
		{
			var input = @"3,1,2";

			var test = new Day15().Run(input);

			Assert.Equal(1836, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day15().Run(TestInput.Day15);

			Assert.Equal(376, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"0,3,6";

			var test = new Day15().Run2(input);

			Assert.Equal(175594, test);
		}

		[Fact]
		public void Run2ExampleB()
		{
			var input = @"1,3,2";

			var test = new Day15().Run2(input);

			Assert.Equal(2578, test);
		}

		[Fact]
		public void Run2ExampleC()
		{
			var input = @"2,1,3";

			var test = new Day15().Run2(input);

			Assert.Equal(3544142, test);
		}

		[Fact]
		public void Run2ExampleD()
		{
			var input = @"1,2,3";

			var test = new Day15().Run2(input);

			Assert.Equal(261214, test);
		}

		[Fact]
		public void Run2ExampleE()
		{
			var input = @"2,3,1";

			var test = new Day15().Run2(input);

			Assert.Equal(6895259, test);
		}

		[Fact]
		public void Run2ExampleF()
		{
			var input = @"3,2,1";

			var test = new Day15().Run2(input);

			Assert.Equal(18, test);
		}

		[Fact]
		public void Run2ExampleG()
		{
			var input = @"3,1,2";

			var test = new Day15().Run2(input);

			Assert.Equal(362, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day15().Run2(TestInput.Day15);

			Assert.Equal(323780, test);
		}
	}
}