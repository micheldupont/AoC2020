using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day12Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"F10
N3
F7
R90
F11";

			var test = new Day12().Run(input);

			Assert.Equal(17 + 8, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day12().Run(TestInput.Day12);

			Assert.Equal(1838, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"F10
N3
F7
R90
F11";

			var test = new Day12().Run2(input);

			Assert.Equal(214 + 72, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day12().Run2(TestInput.Day12);

			Assert.Equal(89936, test);
		}
	}
}