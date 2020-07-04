using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using task_1;


namespace task_2
{
    public class Complex : IEquatable<Complex>, IComparable<Complex>, IComparable, ICloneable
    {
        public Complex(Fraction real, Fraction imagine )
        {
            Imagine = imagine;
            Real = real;
        }

        public Fraction Real { get; private set; }
        public Fraction Imagine { get; private set; }

        #region Arithmetic
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

        public static Complex Module(Complex c, BigInteger precision)
        {
            return new Complex( Fraction.Sqrt((c.Real ^ 2) + (c.Imagine ^ 2), new Fraction(1, precision)), new Fraction(0, 1));
        }

        public static Complex Argument(Complex c, int precision)
        {
            Fraction x = c.Real;
            Fraction y = c.Imagine;
            Fraction zero = new Fraction(0);
            Fraction PI = new Fraction(22,7);
            
            if (x > zero)
            {
                return new Complex(Fraction.Arctan(y / x, precision), new Fraction(0));
            }

            if (x < zero && y >= zero)
            {
                return new Complex(PI + Fraction.Arctan(y / x, precision), new Fraction(0));
            }
            
            if (x < zero && y < zero)
            {
                return new Complex(-1*PI + Fraction.Arctan(y / x, precision), new Fraction(0));
            }
            
            if (x == zero && y > zero)
            {
                return new Complex(PI/2, new Fraction(0));
            }
            
            if (x == zero && y < zero)
            {
                return new Complex(-1*PI/2, new Fraction(0));
            }

            throw new ArgumentException("Smtng wrng");
        }

        public static Complex Pow(Complex c, BigInteger d, int precision)
        {
            Fraction arg = Complex.Argument(c, precision).Real;
            Fraction module = Complex.Module(c, precision).Real;

            return new Complex((module ^ d) * Fraction.Cos(d * arg, precision),
                (module ^ d) * Fraction.Sin(d * arg, precision));
        }
        
        public static List<Complex> Sqrt(Complex c, int d, int precision)
        {
            Fraction arg = Complex.Argument(c, precision / 4).Real;
            Fraction module = Complex.Module(c, precision / 4).Real;
            Fraction PI = new Fraction(22,7);
            List<Complex> result = new List<Complex>();
            Fraction s = Fraction.Sqrt(module, new Fraction(1, precision ), d);
            for (BigInteger i = 0; i < d; i++)
            {
                result.Add(new Complex( s * (Fraction.Cos((arg + 2*i*PI )/ d, precision / 4)),
                    s * (Fraction.Sin((arg + 2*i*PI )/ d, precision / 4))));
            }

            return result;
        }
        
        #endregion

        public bool Equals(Complex? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Real.Equals(other.Real)  && Imagine.Equals( other.Imagine);
        }

        public int CompareTo(Complex? other)
        {
            if (other is null) throw new ArgumentNullException();
            if (Real > other.Real) return 1;
            if (Real < other.Real) return -1;
            if (Imagine < other.Imagine) return -1;
            if (Imagine > other.Imagine) return 1;
            return 0;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Complex) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imagine);
        }

        public object Clone()
        {
            return new Complex((Fraction) Real.Clone(), (Fraction) Imagine.Clone());
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) throw new ArgumentNullException();
            var c = obj as Complex;
            if (c == null) throw new ArgumentNullException();
            else return CompareTo(c);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Real);
            sb.Append(" + i(");
            sb.Append(Imagine);
            sb.Append(")");
            return sb.ToString();
        }

        public string ToDouble(int precision)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Real.ToDecimalString(precision));
            sb.Append(" + i(");
            sb.Append(Imagine.ToDecimalString(precision));
            sb.Append(")");
            return sb.ToString();
        }
    }
}