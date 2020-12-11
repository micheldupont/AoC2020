using System;
using System.Collections.Generic;
using aoc_code;
using aoc_tests.TestInputs;
using Xunit;

namespace aoc_tests
{
	public class Day10Tests
	{
		[Fact]
		public void Run1ExampleA()
		{
			var input = @"16
10
15
5
1
11
7
19
6
12
4";
			var test = new Day10().Run(input);

			Assert.Equal(7 * 5, test);
		}

		[Fact]
		public void Run1ExampleB()
		{
			var input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
			var test = new Day10().Run(input);

			Assert.Equal(22 * 10, test);
		}

		[Fact]
		public void Run1Mine()
		{
			var test = new Day10().Run(TestInput.Day10);

			Assert.Equal(2380, test);
		}

		[Fact]
		public void RunPermutationTestA()
		{
			var test = new Day10().CalculatePermutations(new[] {1, 2});

			Assert.Equal((ulong) 1, test);
		}

		[Fact]
		public void RunPermutationTestB()
		{
			var test = new Day10().CalculatePermutations(new[] {1, 2, 3});

			Assert.Equal((ulong) 2, test);
		}

		[Fact]
		public void RunPermutationTestC()
		{
			var test = new Day10().CalculatePermutations(new[] {1, 2, 3, 4});

			Assert.Equal((ulong) 4, test);
		}

		[Fact]
		public void RunPermutationTestD()
		{
			var test = new Day10().CalculatePermutations(new[] {45, 46, 47, 48, 49});

			Assert.Equal((ulong) 7, test);
		}

		[Fact]
		public void Run2ExampleA()
		{
			var input = @"16
10
15
5
1
11
7
19
6
12
4";
			var test = new Day10().Run2(input);

			Assert.Equal((ulong) 8, test);
		}

		[Fact]
		public void Run2ExampleB()
		{
			var input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
			var test = new Day10().Run2(input);

			Assert.Equal((ulong) 19208, test);
		}

		[Fact]
		public void Run2Mine()
		{
			var test = new Day10().Run2(TestInput.Day10);

			Assert.Equal((ulong) 48358655787008, test);
		}
	}
}