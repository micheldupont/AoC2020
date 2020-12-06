using System;
using Xunit;
using aoc_code;

namespace aoc_tests
{
    public class Day6Tests
    {
        
        [Fact]
        public void Run1ExampleA() {

            var input = @"abcx
abcy
abcz";

            var test = new Day6().Run(input);

            Assert.Equal(6, test);
        }

        [Fact]
        public void Run1ExampleB() {

            var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";

            var test = new Day6().Run(input);

            Assert.Equal(11, test);
        }

        [Fact]
        public void Run1Mine() {
            var test = new Day6().Run(TestInputs.Day6);

            Assert.Equal(6259, test);
        }

        [Fact]
        public void Run2ExampleA() {

            var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";

            var test = new Day6().Run2(input);

            Assert.Equal(6, test);
        }

        [Fact]
        public void Run2Mine() {
            var test = new Day6().Run2(TestInputs.Day6);

            Assert.Equal(3178, test);
        }
    }
}