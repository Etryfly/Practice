using System;
using static task_1.Fraction;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Fraction frac = new Fraction(1,2);
            Console.WriteLine(frac.ToDecimalString(5));
            
            Fraction frac2 = new Fraction(2,3);
            Console.WriteLine(frac*frac2);
            Console.WriteLine(frac!=frac2);
        }
    }
}