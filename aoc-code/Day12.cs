using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Ship
	{
		private int Heading { get; set; } = 1; // models an array with directions in CW sequence [ N, E, S, W ]

		private int PosX { get; set; }
		private int PosY { get; set; }

		public int Manhattan => Math.Abs(PosX) + Math.Abs(PosY);

		public void MoveN(int value) => PosY += value;
		public void MoveS(int value) => PosY -= value;
		public void MoveE(int value) => PosX += value;
		public void MoveW(int value) => PosX -= value;

		public void RotateL(int value)
		{
			var quarterTurns = value / 90;

			Heading -= quarterTurns;
			if (Heading < 0)
			{
				Heading += 4;
			}
		}

		public void RotateR(int value)
		{
			var quarterTurns = value / 90;

			Heading += quarterTurns;
			if (Heading > 3)
			{
				Heading -= 4;
			}
		}

		public void MoveF(int value)
		{
			switch (Heading)
			{
				case 0:
					MoveN(value);
					break;
				case 1:
					MoveE(value);
					break;
				case 2:
					MoveS(value);
					break;
				case 3:
					MoveW(value);
					break;
			}
		}
	}

	public class Ship2
	{
		private int PosX { get; set; }
		private int PosY { get; set; }

		private int WPX { get; set; } = 10;
		private int WPY { get; set; } = 1;


		public int Manhattan => Math.Abs(PosX) + Math.Abs(PosY);

		public void MoveWPN(int value) => WPY += value;
		public void MoveWPS(int value) => WPY -= value;
		public void MoveWPE(int value) => WPX += value;
		public void MoveWPW(int value) => WPX -= value;

		public void RotateWPL(int value)
		{
			switch (value) //rotating CCW (left) can be converted to CW (right)
			{
				case 90:
					RotateWPR(270);
					break;
				case 180:
					RotateWPR(180);
					break;
				case 270:
					RotateWPR(90);
					break;
			}
		}

		public void RotateWPR(int value)
		{
			var oldWPX = WPX;
			var oldWPY = WPY;

			switch (value)
			{
				case 90:
					WPX = oldWPY;
					WPY = -1 * oldWPX;
					break;
				case 180:
					WPX = -1 * oldWPX;
					WPY = -1 * oldWPY;
					break;
				case 270:
					WPX = -1 * oldWPY;
					WPY = oldWPX;
					break;
			}
		}

		public void MoveF(int value)
		{
			for (var i = 0; i < value; i++)
			{
				PosX += WPX;
				PosY += WPY;
			}
		}
	}

	public class Day12
	{
		public int Run(string input)
		{
			var instructions = input.Split("\r\n").Select(l =>
				new Tuple<char, int>(l.Substring(0, 1).ToCharArray()[0], int.Parse(l.Substring(1)))).ToList();

			var ship = new Ship();

			foreach (var instruction in instructions)
			{
				switch (instruction.Item1)
				{
					case 'N':
						ship.MoveN(instruction.Item2);
						break;
					case 'S':
						ship.MoveS(instruction.Item2);
						break;
					case 'E':
						ship.MoveE(instruction.Item2);
						break;
					case 'W':
						ship.MoveW(instruction.Item2);
						break;
					case 'L':
						ship.RotateL(instruction.Item2);
						break;
					case 'R':
						ship.RotateR(instruction.Item2);
						break;
					case 'F':
						ship.MoveF(instruction.Item2);
						break;
				}
			}


			return ship.Manhattan;
		}

		public int Run2(string input)
		{
			var instructions = input.Split("\r\n").Select(l =>
				new Tuple<char, int>(l.Substring(0, 1).ToCharArray()[0], int.Parse(l.Substring(1)))).ToList();

			var ship = new Ship2();

			foreach (var instruction in instructions)
			{
				switch (instruction.Item1)
				{
					case 'N':
						ship.MoveWPN(instruction.Item2);
						break;
					case 'S':
						ship.MoveWPS(instruction.Item2);
						break;
					case 'E':
						ship.MoveWPE(instruction.Item2);
						break;
					case 'W':
						ship.MoveWPW(instruction.Item2);
						break;
					case 'L':
						ship.RotateWPL(instruction.Item2);
						break;
					case 'R':
						ship.RotateWPR(instruction.Item2);
						break;
					case 'F':
						ship.MoveF(instruction.Item2);
						break;
				}
			}


			return ship.Manhattan;
		}
	}
}