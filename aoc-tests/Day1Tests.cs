using System;
using Xunit;
using aoc_code;

namespace aoc_tests
{
    public class Day1Tests
    {
        [Fact]
        public void Run1Example()
        {
            var input = @"1721
979
366
299
675
1456";

            var test = new Day1().Run(input);
            Assert.Equal(test, 514579);
        }

        [Fact]
        public void Run1Mine()
        {
            var test = new Day1().Run(TestInputs.Day1);
            Assert.Equal(test, 870331);
        }

        [Fact]
        public void Run2Example()
        {
            var input = @"1721
979
366
299
675
1456";

            var test = new Day1().Run2(input);
            Assert.Equal(test, 241861950);
        }

        [Fact]
        public void Run2Mine()
        {
            var test = new Day1().Run2(TestInputs.Day1);
            Assert.Equal(test, 283025088);
        }
    }
}
