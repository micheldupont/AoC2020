using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace aoc_code
{
    public class Day3 {

        public int Run(string input, int slopeRight, int slopeDown) {

            var lines = input.Split(new char[]{'\r','\n'}, StringSplitOptions.RemoveEmptyEntries);
            var lineWidth = lines[0].Length;
            var lineCount = lines.Length;

            var field = new char[lineWidth,lineCount];

            for(int y = 0; y < lineCount; y++) {
                var lineChars = lines[y].ToCharArray();

                for(int x = 0; x < lineWidth; x++) {
                    var lc = lineChars[x];
                    field[x,y] = lc; 
                }
            }

            var posX = 0;
            var posY = 0;
            var treeHits = 0;

            while(posY < lineCount) {
                if(field[posX,posY] == '#') {
                    treeHits++;
                }

                posX = posX + slopeRight;
                posY = posY + slopeDown;

                if(posX > lineWidth -1){ //overflow to the right : repeat
                    posX = posX % lineWidth;
                }
            }

            return treeHits;
        }

        public Int64 Run2(string input) {
            Int64 a = this.Run(input, 1,1);
            Int64 b = this.Run(input, 3,1);
            Int64 c = this.Run(input, 5,1);
            Int64 d = this.Run(input, 7,1);
            Int64 e = this.Run(input, 1,2);

            return a*b*c*d*e;
        }

    }
}