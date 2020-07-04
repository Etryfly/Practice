using System;
using static task_1.Fraction;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Fraction frac = new Fraction(3,1);
            
            
            Console.WriteLine(Fraction.Sqrt(frac, new Fraction(1, 100),3).ToDecimalString(3));
            //
            // Fraction frac2 = new Fraction(2,3);
            // Console.WriteLine(frac*frac2);
            // Console.WriteLine(frac!=frac2);
            // Fraction frac3 = new Fraction(0,1);
            // try
            // {
            //     Console.WriteLine(frac / frac2);
            //     Console.WriteLine(frac / frac3);
            //     
            // }
            // catch (ArgumentException e)
            // {
            //     Console.WriteLine(e.Message);
            // }
            //
            // Console.WriteLine(frac^5);
            // Console.WriteLine(frac+frac2);
            // Console.WriteLine(Fraction.Sqrt(new Fraction(1,3), new Fraction(1, 10000000000000)).ToDecimalString(1000));
        }
    }
}