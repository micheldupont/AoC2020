using System;
using Xunit;
using aoc_code;

namespace aoc_tests
{
    public class Day3Tests
    {
        [Fact]
        public void Run1Example()
        {
            var input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

            var test = new Day3().Run(input, 3, 1);
            Assert.Equal(test, 7);
        }

        [Fact]
        public void Run1Mine()
        {
            var test = new Day3().Run(TestInputs.Day3, 3, 1);
            Assert.Equal(test, 286);
        }

        [Fact]
        public void Run2Example()
        {
            var input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

            var test = new Day3().Run2(input);
            Assert.Equal(test, 336);
        }

        [Fact]
        public void Run2Mine()
        {
            var test = new Day3().Run2(TestInputs.Day3);
            Assert.Equal(test, 3638606400);
        }
    }
}