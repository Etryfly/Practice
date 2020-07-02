using System;
using System.Numerics;
using task_1;


namespace task_2
{
    public class Complex
    {
        public Complex(Fraction real, Fraction imagine )
        {
            Imagine = imagine;
            Real = real;
        }

        public Fraction Real { get; private set; }
        public Fraction Imagine { get; private set; }

        public static Complex Sum(Complex left, Complex right)
        {
            return new Complex(left.Real + right.Real, left.Imagine + right.Imagine);
        }

        public static Complex Subtraction(Complex left, Complex right)
        {
            return new Complex(left.Real - right.Real, left.Imagine - right.Imagine);
        }

        public static Complex Multiply(Complex left, Complex right)
        {
            return new Complex(left.Real * right.Real - left.Imagine*right.Imagine,
                left.Real*right.Imagine + left.Imagine*right.Real);
        }

        public static Complex Divide(Complex left, Complex right)
        {
            Fraction a = left.Real;
            Fraction b = left.Imagine;
            Fraction c = right.Real;
            Fraction d = right.Imagine;

            return new Complex((a * c + b * d) / (c * c + d * d), (b * c - a * d) / (c * c + d * d));
        }

        public static Complex operator +(Complex left, Complex right)
        {
            return Sum(left, right);
        }
        
        public static Complex operator -(Complex left, Complex right)
        {
            return Subtraction(left, right);
        }
        
        public static Complex operator *(Complex left, Complex right)
        {
            return Multiply(left, right);
        }
        
        public static Complex operator /(Complex left, Complex right)
        {
            return Divide(left, right);
        }

        public static Complex Module(Complex c)
        {
            return new Complex( Fraction.Sqrt((c.Real ^ 2) + c.Imagine ^ 2), new Fraction(0, 1));
        }
    }
}