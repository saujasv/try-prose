namespace Solver
{
    public static class Semantics
    {
        public static char A(char c)
        {
            if (c == 'a')
            {
                return 'b';
            }

            return c;
        }

        public static char Ident(char c)
        {
            return c;
        }
    }
}