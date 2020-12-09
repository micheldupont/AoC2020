using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day2Tests
	{
		[Fact]
		public void Run1Example()
		{
			var input = @"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

			var test = new Day2().Run(input);
			Assert.Equal(test, 2);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day2().Run(TestInput.Day2);
			Assert.Equal(test, 638);
		}

		[Fact]
		public void Run2Example()
		{
			var input = @"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

			var test = new Day2().Run2(input);
			Assert.Equal(test, 1);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day2().Run2(TestInput.Day2);
			Assert.Equal(test, 699);
		}
	}
}