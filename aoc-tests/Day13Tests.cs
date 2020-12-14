using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day13Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"939
7,13,x,x,59,x,31,19";

			var test = new Day13().Run(input);

			Assert.Equal(59 * 5, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day13().Run(TestInput.Day13);

			Assert.Equal(1835, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"939
7,13,x,x,59,x,31,19";

			var test = new Day13().Run2(input);

			Assert.Equal((ulong) 1068781, test);
		}

		[Fact]
		public void Run2ExampleB()
		{
			var input = @"939
17,x,13,19";

			var test = new Day13().Run2(input);

			Assert.Equal((ulong) 3417, test);
		}

		[Fact]
		public void Run2ExampleC()
		{
			var input = @"939
67,7,59,61";

			var test = new Day13().Run2(input);

			Assert.Equal((ulong) 754018, test);
		}

		[Fact]
		public void Run2ExampleD()
		{
			var input = @"939
67,x,7,59,61";

			var test = new Day13().Run2(input);

			Assert.Equal((ulong) 779210, test);
		}

		[Fact]
		public void Run2ExampleE()
		{
			var input = @"939
67,7,x,59,61";

			var test = new Day13().Run2(input);

			Assert.Equal((ulong) 1261476, test);
		}

		[Fact]
		public void Run2ExampleF()
		{
			var input = @"939
1789,37,47,1889";

			var test = new Day13().Run2(input);

			Assert.Equal((ulong) 1202161486, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day13().Run2(TestInput.Day13);

			Assert.Equal((ulong) 247086664214628, test);
		}
	}
}