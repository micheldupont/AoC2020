using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day7Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

			var test = new Day7().Run(input);

			Assert.Equal(4, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day7().Run(TestInput.Day7);

			Assert.Equal(115, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

			var test = new Day7().Run2(input);

			Assert.Equal(32, test);
		}

		[Fact]
		public void Run2ExampleB()
		{
			var input = @"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";

			var test = new Day7().Run2(input);

			Assert.Equal(126, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day7().Run2(TestInput.Day7);

			Assert.Equal(1250, test);
		}
	}
}