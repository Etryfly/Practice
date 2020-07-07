using System;
using System.Diagnostics;
using System.Numerics;
using task_1;

namespace task_4
{
    
    
    class Program
    {

        public static Fraction foo(Fraction x)
        {
            return x*x;
        }
        
        static void Main(string[] args)
        {
            BigInteger n = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            LeftRectangle left = new LeftRectangle();
            Fraction lR = left.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100), out n);
            stopwatch.Stop();
            Console.WriteLine(lR.ToDecimalString(3) + " " + n +" " + stopwatch.ElapsedMilliseconds);
            
            stopwatch = new Stopwatch();
            stopwatch.Start();
            RightRectagnle right = new RightRectagnle();
            Fraction rR = right.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100), out n);
            Console.WriteLine(rR.ToDecimalString(3) + " " + n + " " +stopwatch.ElapsedMilliseconds) ;
            
            stopwatch = new Stopwatch();
            stopwatch.Start();
            MiddleRectangle mid = new MiddleRectangle();
            Fraction mR = mid.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100), out n);
            Console.WriteLine(mR.ToDecimalString(3) + " " + n +" " + stopwatch.ElapsedMilliseconds);
            
            stopwatch = new Stopwatch();
            stopwatch.Start();
            Trapeze trapeze = new Trapeze();
            Fraction tIntegrate = trapeze.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100), out n);
            Console.WriteLine(tIntegrate.ToDecimalString(3) + " " + n + " " + stopwatch.ElapsedMilliseconds);
            
            stopwatch = new Stopwatch();
            stopwatch.Start();
            Simpson simpson = new Simpson();
            Fraction sIntegrate = simpson.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100), out n);
            Console.WriteLine(sIntegrate.ToDecimalString(3) + " " + n +" " + stopwatch.ElapsedMilliseconds);
        }
    }
}