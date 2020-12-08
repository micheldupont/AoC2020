using System.Transactions;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace aoc_code
{
    public class Day8
    {
        public int Run(string input)
        {
            var instructions = this.ParseInstructions(input);

            var accumulator = 0;
            this.RunToEnd(ref instructions, ref accumulator);

            return accumulator;
        }

        public int Run2(string input)
        {
            var instructions = this.ParseInstructions(input);

            var runResult = "";
            var mutatedIndex = 0;
            var accumulator = 0;

            while(runResult != "done")
            {
                accumulator = 0;
                var mutatedProgram = this.Mutate(ref instructions, mutatedIndex);
                runResult = this.RunToEnd(ref mutatedProgram, ref accumulator);

                mutatedIndex += 1;
                
            }
            
            return accumulator;
        }

        private List<Instruction> ParseInstructions(string input)
        {
            var instructions = new List<Instruction>();

            var lines = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in lines)
            {
                var parts = line.Split(" ");
                var op = parts[0];
                var arg = Int32.Parse(parts[1]);

                instructions.Add(new Instruction{Op = op, Arg = arg});
            }

            return instructions;
        }

        private string RunToEnd(ref List<Instruction> instructions, ref int accumulator)
        {
            instructions.ForEach(i => i.Done = false);

            var instructionIndex = 0;
            var currentInstruction = instructions[instructionIndex];
            var programLength = instructions.Count;

            while(!currentInstruction.Done)
            {
                var jumpValue = currentInstruction.Run(ref accumulator);
                instructionIndex += jumpValue;
                
                if(instructionIndex >= programLength)
                {
                    return "done";
                }
                currentInstruction = instructions[instructionIndex];
            }

            return "loop";
        }

        private List<Instruction> Mutate(ref List<Instruction> origProgram, int mutateIndex)
        {
            var prog = origProgram.Select(i => new Instruction(i)).ToList();

            var toMutate = prog[mutateIndex];

            if(toMutate.Op == "nop") 
            {
                toMutate.Op = "jmp";
            } else if(toMutate.Op == "jmp") 
            {
                toMutate.Op = "nop";
            }

            return prog;
        }
    }

    public class Instruction {
        public string Op { get; set; }
        public int Arg { get; set; }
        public bool Done { get; set; }

        public Instruction() { }
        public Instruction(Instruction toCopy)
        {
            this.Op = toCopy.Op;
            this.Arg = toCopy.Arg;
            this.Done = false;
        }

        public int Run(ref int accumulator)
        {
            this.Done = true;
            switch(this.Op)
            {
                case "acc":
                    accumulator += this.Arg;
                    return 1;
                case "jmp":
                    return this.Arg;
                case "nop":
                default:
                    return 1;
             }
        }
    }
}