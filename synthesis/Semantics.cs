using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solver
{
    public static class Semantics
    {
        public static int[] GetIndices(char[] v)
        {
            return Enumerable.Range(0, v.Length).ToArray();
        }

        public static char Censor(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return '*';
            }
            return v[i];
        }

        public static char Ident(int i, char[] v)
        {
            return v[i];
        }

        public static Func<char[], int, bool> IsChar(char c) => (s, j) => s[j] == c;

        public static Func<char[], int, bool> True() => (s, j) => true;
    }
}