using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Rules;
using Microsoft.ProgramSynthesis.Specifications;

namespace Solver
{
    public static class Learners
    {
        public static char[] CharGen = {'a', 'b', 'c'};
    }

    public class WitnessFunctions : DomainLearningLogic
    {
        public WitnessFunctions(Grammar grammar) : base(grammar)
        {
        }

        [WitnessFunction(nameof(Semantics.IsChar), 0)]
        public DisjunctiveExamplesSpec WitnessStartPosition(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();

            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = inputState[rule.Body[0]] as char[];
                var output = example.Value as char[];
                var censoredChars = new List<char>();

                for (int i = 0; i < input.Length; i++)
                {
                    if (output[i] == '*')
                    {
                        censoredChars.Add(input[i]);
                    }
                }

                if (censoredChars.Count == 0) return null;
                result[inputState] = censoredChars.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }
    }
}