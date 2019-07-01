﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;
using Microsoft.ProgramSynthesis.Compiler;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Learning.Strategies;
using Microsoft.ProgramSynthesis.Specifications;
using Microsoft.ProgramSynthesis.VersionSpace;

namespace Solver
{
    class Program
    {
        private static readonly Grammar grammar = DSLCompiler.Compile(new CompilerOptions()
        {
            InputGrammarText = File.ReadAllText("synthesis/grammar/solver.grammar"),
            References = CompilerReference.FromAssemblyFiles(typeof(Program).GetTypeInfo().Assembly)
        }).Value;

        private static SynthesisEngine engine;

        private static readonly Dictionary<State, object> Examples = new Dictionary<State, object>();
        private static ProgramNode _topProgram;
        static void Main(string[] args)
        {
            engine = ConfigureSynthesis();
            
            var menu = @"Select one of the options: 
1 - provide new example
2 - run top synthesized program on a new input
3 - exit";
            var option = 0;
            while (option != 3)
            {
                Console.Out.WriteLine(menu);
                try
                {
                    option = short.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Out.WriteLine("Invalid option. Try again.");
                    continue;
                }

                try
                {
                    RunOption(option);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Something went wrong...");
                    Console.Error.WriteLine("Exception message: {0}", e.Message);
                }
            }
        }

        private static void RunOption(int option)
        {
            switch (option)
            {
                case 1:
                    LearnFromNewExample();
                    break;
                case 2:
                    RunOnNewInput();
                    break;
                default:
                    Console.Out.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void LearnFromNewExample()
        {
            Console.Out.Write("Provide a new input-output example (e.g., \"(Sumit Gulwani)\",\"Gulwani\"): ");
            try
            {
                string input = Console.ReadLine();
                if (input != null)
                {
                    int startFirstExample = input.IndexOf("\"", StringComparison.Ordinal) + 1;
                    int endFirstExample = input.IndexOf("\"", startFirstExample + 1, StringComparison.Ordinal) + 1;
                    int startSecondExample = input.IndexOf("\"", endFirstExample + 1, StringComparison.Ordinal) + 1;
                    int endSecondExample = input.IndexOf("\"", startSecondExample + 1, StringComparison.Ordinal) + 1;

                    if (startFirstExample >= endFirstExample || startSecondExample >= endSecondExample)
                        throw new Exception(
                            "Invalid example format. Please try again. input and out should be between quotes");

                    string inputExample = input.Substring(startFirstExample, endFirstExample - startFirstExample - 1);
                    char[] inputExampleArray = inputExample.ToCharArray();
                    string outputExample =
                        input.Substring(startSecondExample, endSecondExample - startSecondExample - 1);
                    char[] outputExampleArray = outputExample.ToCharArray();

                    State inputState = State.CreateForExecution(grammar.InputSymbol, inputExampleArray);
                    Examples.Add(inputState, outputExampleArray);
                }
            }
            catch (Exception)
            {
                throw new Exception("Invalid example format. Please try again. input and out should be between quotes");
            }

            var spec = new ExampleSpec(Examples);
            Console.Out.WriteLine("Learning a program for examples:");
            foreach (KeyValuePair<State, object> example in Examples)
                Console.WriteLine("\"{0}\" -> \"{1}\"", example.Key.Bindings.First().Value, example.Value);

            ProgramSet topPrograms = engine.LearnGrammar(spec);
            if (topPrograms.IsEmpty)
                throw new Exception("No program was found for this specification.");

            _topProgram = topPrograms.RealizedPrograms.First();
            Console.Out.WriteLine("Top 4 learned programs:");
            var counter = 1;
            foreach (ProgramNode program in topPrograms.RealizedPrograms)
            {
                if (counter > 4) break;
                Console.Out.WriteLine("==========================");
                Console.Out.WriteLine("Program {0}: ", counter);
                Console.Out.WriteLine(program.PrintAST(ASTSerializationFormat.HumanReadable));
                counter++;
            }
        }

        private static void RunOnNewInput()
        {
            if (_topProgram == null)
                throw new Exception("No program was synthesized. Try to provide new examples first.");
            Console.Out.WriteLine("Top program: {0}", _topProgram);

            try
            {
                Console.Out.Write("Insert a new input: ");
                string newInput = Console.ReadLine();
                if (newInput != null)
                {
                    int startFirstExample = newInput.IndexOf("\"", StringComparison.Ordinal) + 1;
                    int endFirstExample = newInput.IndexOf("\"", startFirstExample + 1, StringComparison.Ordinal) + 1;
                    newInput = newInput.Substring(startFirstExample, endFirstExample - startFirstExample - 1);
                    State newInputState = State.CreateForExecution(grammar.InputSymbol, newInput);
                    Console.Out.WriteLine("RESULT: \"{0}\" -> \"{1}\"", newInput, _topProgram.Invoke(newInputState));
                }
            }
            catch (Exception)
            {
                throw new Exception("The execution of the program on this input thrown an exception");
            }
        }

        public static SynthesisEngine ConfigureSynthesis()
        {
            var witnessFunctions = new WitnessFunctions(grammar);
            var deductiveSynthesis = new DeductiveSynthesis(witnessFunctions);
            var synthesisExtrategies = new ISynthesisStrategy[] {deductiveSynthesis};
    var synthesisConfig = new SynthesisEngine.Config {Strategies = synthesisExtrategies};
            var prose = new SynthesisEngine(grammar);
            return prose;
        }
    }
}
