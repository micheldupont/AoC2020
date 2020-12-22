using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day21Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)";

			var test = new Day21().Run(input);

			Assert.Equal(5, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day21().Run(TestInput.Day21);

			Assert.Equal(1913, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)";

			var test = new Day21().Run2(input);

			Assert.Equal("mxmxvkd,sqjhc,fvjkl", test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day21().Run2(TestInput.Day21);

			Assert.Equal("gpgrb,tjlz,gtjmd,spbxz,pfdkkzp,xcfpc,txzv,znqbr", test);
		}
	}
}