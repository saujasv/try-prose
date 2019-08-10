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

        public static char ToStar(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return '*';
            }
            return v[i];
        }

        public static char ToA(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'a';
            }
            return v[i];
        }
        public static char ToB(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'b';
            }
            return v[i];
        }
        public static char ToC(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'c';
            }
            return v[i];
        }
        public static char ToD(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'd';
            }
            return v[i];
        }
        public static char ToE(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'e';
            }
            return v[i];
        }
        public static char ToF(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'f';
            }
            return v[i];
        }
        public static char ToG(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'g';
            }
            return v[i];
        }
        public static char ToH(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'h';
            }
            return v[i];
        }
        public static char ToI(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'i';
            }
            return v[i];
        }
        public static char ToJ(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'j';
            }
            return v[i];
        }
        public static char ToK(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'k';
            }
            return v[i];
        }
        public static char ToL(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'l';
            }
            return v[i];
        }
        public static char ToM(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'm';
            }
            return v[i];
        }
        public static char ToN(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'n';
            }
            return v[i];
        }
        public static char ToO(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'o';
            }
            return v[i];
        }
        public static char ToP(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'p';
            }
            return v[i];
        }
        public static char ToQ(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'q';
            }
            return v[i];
        }
        public static char ToR(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'r';
            }
            return v[i];
        }
        public static char ToS(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 's';
            }
            return v[i];
        }
        public static char ToT(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 't';
            }
            return v[i];
        }
        public static char ToU(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'u';
            }
            return v[i];
        }
        public static char ToV(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'v';
            }
            return v[i];
        }
        public static char ToW(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'w';
            }
            return v[i];
        }
        public static char ToX(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'x';
            }
            return v[i];
        }
        public static char ToY(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'y';
            }
            return v[i];
        }
        public static char ToZ(int i, char[] v, Func<char[], int, bool> pred)
        {
            if (pred(v, i))
            {
                return 'z';
            }
            return v[i];
        }

        public static char Ident(int i, char[] v)
        {
            return v[i];
        }

        public static Func<char[], int, bool> IsA() => (s, j) => s[j] == 'a';
        public static Func<char[], int, bool> IsB() => (s, j) => s[j] == 'b';
        public static Func<char[], int, bool> IsC() => (s, j) => s[j] == 'c';
        public static Func<char[], int, bool> IsD() => (s, j) => s[j] == 'd';
        public static Func<char[], int, bool> IsE() => (s, j) => s[j] == 'e';
        public static Func<char[], int, bool> IsF() => (s, j) => s[j] == 'f';
        public static Func<char[], int, bool> IsG() => (s, j) => s[j] == 'g';
        public static Func<char[], int, bool> IsH() => (s, j) => s[j] == 'h';
        public static Func<char[], int, bool> IsI() => (s, j) => s[j] == 'i';
        public static Func<char[], int, bool> IsJ() => (s, j) => s[j] == 'j';
        public static Func<char[], int, bool> IsK() => (s, j) => s[j] == 'k';
        public static Func<char[], int, bool> IsL() => (s, j) => s[j] == 'l';
        public static Func<char[], int, bool> IsM() => (s, j) => s[j] == 'm';
        public static Func<char[], int, bool> IsN() => (s, j) => s[j] == 'n';
        public static Func<char[], int, bool> IsO() => (s, j) => s[j] == 'o';
        public static Func<char[], int, bool> IsP() => (s, j) => s[j] == 'p';
        public static Func<char[], int, bool> IsQ() => (s, j) => s[j] == 'q';
        public static Func<char[], int, bool> IsR() => (s, j) => s[j] == 'r';
        public static Func<char[], int, bool> IsS() => (s, j) => s[j] == 's';
        public static Func<char[], int, bool> IsT() => (s, j) => s[j] == 't';
        public static Func<char[], int, bool> IsU() => (s, j) => s[j] == 'u';
        public static Func<char[], int, bool> IsV() => (s, j) => s[j] == 'v';
        public static Func<char[], int, bool> IsW() => (s, j) => s[j] == 'w';
        public static Func<char[], int, bool> IsX() => (s, j) => s[j] == 'x';
        public static Func<char[], int, bool> IsY() => (s, j) => s[j] == 'y';
        public static Func<char[], int, bool> IsZ() => (s, j) => s[j] == 'z';

        public static Func<char[], int, bool> True() => (s, j) => true;
        public static Func<char[], int, bool> False() => (s, j) => false;

        public static Func<char[], int, bool> OR(Func<char[], int, bool> f, Func<char[], int, bool> g)
        {
            return (s, j) => (f(s, j) | g(s, j));
        }
    }
}