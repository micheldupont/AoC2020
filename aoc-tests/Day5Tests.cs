using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day5Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"FBFBBFFRLR";

			var test = new Day5().Run(input);

			Assert.Equal(357, test);
		}

		[Fact]
		public void Run1ExampleB()
		{
			var input = @"BFFFBBFRRR";

			var test = new Day5().Run(input);

			Assert.Equal(567, test);
		}

		[Fact]
		public void Run1ExampleC()
		{
			var input = @"FFFBBBFRRR";

			var test = new Day5().Run(input);

			Assert.Equal(119, test);
		}

		[Fact]
		public void Run1ExampleD()
		{
			var input = @"BBFFBBFRLL";

			var test = new Day5().Run(input);

			Assert.Equal(820, test);
		}

		[Fact]
		public void Run1ExampleE()
		{
			var input = @"FBFBBFFRLR
BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL";

			var test = new Day5().Run(input);

			Assert.Equal(820, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day5().Run(TestInput.Day5);

			Assert.Equal(933, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day5().Run2(TestInput.Day5);

			Assert.Equal(711, test);
		}
	}
}