using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace aoc_code
{
    public class PwPolicy {
        public int atLeast { get; set; }
        public int atMost { get; set; }
        public int targetChar { get; set; }

        public char[] Pw { get; set; }
    }

    public class PwPolicy2 {
        public int indexA { get; set; }
        public int indexB { get; set; }
        public int targetChar { get; set; }

        public char[] Pw { get; set; }
    }

    public class Day2
    {
        private Regex _knownFormat = new Regex("^([0-9]*)-([0-9]*) ([a-z]): ([a-z]*)$");

        public int Run(string inputStr) {

            var inputArr = new List<PwPolicy>();

            var inputs = inputStr.Split(new char[]{'\r','\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var i in inputs) {
                
                var p = _knownFormat.Split(i);

                inputArr.Add(new PwPolicy{
                    atLeast = Int32.Parse(p[1]),
                    atMost = Int32.Parse(p[2]),
                    targetChar = p[3][0],
                    Pw = p[4].ToCharArray()
                });
            }

            var valid = 0;

            foreach(var pw in inputArr){
                var c = pw.targetChar;
                var cCount = pw.Pw.Count(i => i == c);
                if(cCount >= pw.atLeast && cCount <= pw.atMost) {
                    valid += 1;
                }
            }


            return valid;
        }

        public int Run2(string inputStr) {

            var inputArr = new List<PwPolicy2>();

            var inputs = inputStr.Split(new char[]{'\r','\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var i in inputs) {
                
                var p = _knownFormat.Split(i);

                inputArr.Add(new PwPolicy2{
                    indexA = Int32.Parse(p[1]),
                    indexB = Int32.Parse(p[2]),
                    targetChar = p[3][0],
                    Pw = p[4].ToCharArray()
                });
            }

            var valid = 0;

            foreach(var pw in inputArr){
                var c = pw.targetChar;
                
                var aOk = pw.Pw[pw.indexA -1] == c;
                var bOk = pw.Pw[pw.indexB -1] == c;

                if( (aOk && !bOk) || (!aOk && bOk)){
                    valid += 1;
                }
            }

            return valid;
        }
    }
}
