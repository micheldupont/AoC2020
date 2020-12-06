using System.Transactions;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace aoc_code
{
    public class Range{
        public int Low { get; set; }
        public int High { get; set; }

        public int Length { get{ return this.High - this.Low + 1; }}

        public Range GetUpperHalf(){
            var midpointIndex = this.Length / 2;

            return new Range{Low = this.Low + midpointIndex,  High = this.High};
        }

        public Range GetLowerHalf(){
            var midpointIndex = this.Length / 2;

            return new Range{Low = this.Low,  High = this.Low + midpointIndex -1};
        }
    }

    public class Day5 {
        public int Run(string input) {
            var seatsId = this.ParseSeatsId(input);

            return seatsId.Max();
        }

        public int Run2(string input) {
            var seatsId = this.ParseSeatsId(input);

            var seatsOrderedById = seatsId.OrderBy(s => s).ToArray();
            for(var i = 0; i < seatsOrderedById.Length - 2; i ++){
                var curr = seatsOrderedById[i];
                var next = seatsOrderedById[i + 1];

                if((next - curr) == 2) {
                    return curr + 1;
                }
            }

            return -1;
        }

        private List<int> ParseSeatsId(string input) {
            return input
                .Split(new char[]{'\r','\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(this.EvalTicket)
                .ToList();
        }

        private int EvalTicket(string input){
            if(input.Length != 10) {
                throw new Exception("invalid input");
            }

            var rows = new Range{ Low = 0, High= 127 };
            var seats = new Range{ Low = 0, High= 7 };

            var rowInput = input.Substring(0, 7);
            var seatInput = input.Substring(7,3);

            foreach(var cmd in rowInput.ToCharArray()){
                if(cmd == 'F'){
                    rows = rows.GetLowerHalf();
                }
                else {
                    rows = rows.GetUpperHalf();
                }
            }

             foreach(var cmd in seatInput.ToCharArray()){
                if(cmd == 'L'){
                    seats = seats.GetLowerHalf();
                }
                else {
                    seats = seats.GetUpperHalf();
                }
            }

            if(rows.Length != 1){
                throw new Exception("something went wrong with rows...");
            }

            if(seats.Length != 1){
                throw new Exception("something went wrong with seats...");
            }

            return (rows.Low * 8) + seats.Low;
        }
    }
}