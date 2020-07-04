using System;
using task_1;

namespace task_3
{
    class Program
    {
        
        delegate Fraction Function(Fraction f);

        private static Fraction FindRoot(Fraction a, Fraction b, Function f, Fraction eps)
        {
            Fraction left = (Fraction) a.Clone();
            Fraction right = (Fraction) b.Clone();
            Fraction zero = new Fraction(0);
            while (Fraction.Abs(left - right) > eps)
            {
                Fraction c = (left + right) / 2;
                if (f(right ) * f(c)< zero)
                {
                    left = c;
                }
                else
                {
                    right = c;
                }
            }

            return (left + right) / 2;

        }

        public static Fraction foo1(Fraction f) // x+1
        {
            return f + 1;
        }
        
        public static Fraction foo2(Fraction f) // (x-2)^3
        {
            return (f - 2)^3;
        }
        
        public static Fraction foo3(Fraction f) // x^2+2*x-5
        {
            return f*f + 2*f - 5;
        }
        
        static void Main(string[] args)
        {
           Console.WriteLine(FindRoot(new Fraction(-5), new Fraction(5), foo1, new Fraction(1, 100)));
           Console.WriteLine(FindRoot(new Fraction(-5), new Fraction(5), foo2, new Fraction(1, 100)));
           Console.WriteLine(FindRoot(new Fraction(-2), new Fraction(5), foo3, new Fraction(1, 10000)).ToDecimalString(3));
        }
    }
}