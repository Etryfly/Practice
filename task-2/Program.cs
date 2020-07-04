using System;
using System.Numerics;
using task_1;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex complex = new Complex(new Fraction(3,2), new Fraction(5, 3));
            Complex complex2 = new Complex(new Fraction(5,7), new Fraction(21, 8));
            Console.WriteLine(complex);
            // Console.WriteLine(complex + complex2);
            Console.WriteLine(complex * complex2);
            Console.WriteLine(complex + complex2);
            Console.WriteLine(complex / complex2);
            Console.WriteLine(complex - complex2);
            Console.WriteLine(Complex.Pow(complex, 3, 10).ToDouble(5));
            
            Console.WriteLine("SQRT");
            Console.WriteLine();
            foreach (var cmplx in Complex.Sqrt(complex, 5, 10))
            {
                Console.WriteLine(cmplx.ToDouble(5));
            }
            
        }
    }
}