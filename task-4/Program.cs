using System;
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
            LeftRectangle left = new LeftRectangle();
            Fraction lR = left.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100));
            Console.WriteLine(lR.ToDecimalString(3));
            RightRectagnle right = new RightRectagnle();
            Fraction rR = right.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100));
            Console.WriteLine(rR.ToDecimalString(3));
            MiddleRectangle mid = new MiddleRectangle();
            Fraction mR = mid.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100));
            Console.WriteLine(mR.ToDecimalString(3));
            
            Trapeze trapeze = new Trapeze();
            Fraction tIntegrate = trapeze.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100));
            Console.WriteLine(tIntegrate.ToDecimalString(3));
            
            Simpson simpson = new Simpson();
            Fraction sIntegrate = simpson.Integrate(foo, new Fraction(-10), new Fraction(5), new Fraction(1, 100));
            Console.WriteLine(sIntegrate.ToDecimalString(3));
        }
    }
}