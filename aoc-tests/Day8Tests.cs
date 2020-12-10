using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day8Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

			var test = new Day8().Run(input);

			Assert.Equal(5, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day8().Run(TestInput.Day8);

			Assert.Equal(1331, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

			var test = new Day8().Run2(input);

			Assert.Equal(8, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day8().Run2(TestInput.Day8);

			Assert.Equal(1121, test);
		}
	}
}