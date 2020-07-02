using System;
using System.Data;
using System.Numerics;
using System.Text;

namespace task_1
{
    public class Fraction : IEquatable<Fraction>, IComparable<Fraction>, IComparable, ICloneable
    {
        public BigInteger up { get; private set; }
        public BigInteger down { get; private set; }
        private BigInteger Gcd(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
            
        }
        
        public Fraction(BigInteger up, BigInteger down)
        {
            this.down = down;
            this.up = up;
            
            if (down == 0) throw new ArgumentException("Деление на 0");
            BigInteger gcd = this.Gcd(up, down);
            this.up /= gcd;
            this.down /= gcd;
        }

        public static Fraction Sum(Fraction left, Fraction right)
        {
            return new Fraction(left.up * right.down + left.down * right.up, left.down * right.down);
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            return Sum(left, right);
        }

        public static Fraction Subtraction(Fraction left, Fraction right)
        {
            right.up *= -1;
            return Sum(left, right);
        }
        
        public static Fraction operator -(Fraction left, Fraction right)
        {
            return Subtraction(left, right);
        }

        public static Fraction Multiply(Fraction left, Fraction right)
        {
            return new Fraction(left.up * right.up, left.down * right.down);
        }
        
        public static Fraction operator *(Fraction left, Fraction right)
        {
            return Multiply(left, right);
        }
        
        public static Fraction Division(Fraction left, Fraction right)
        {
            BigInteger up = right.up;
            right.up = right.down;
            right.down = up;
            return left * right;
        }
        
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return Division(left, right);
        }
        
        public static Fraction Pow(Fraction left, int degree)
        {
            for (int i = 0; i < degree; i++)
            {
                left.up *= left.up;
                left.down *= left.down;
            }

            return left;
        }
        
        public static Fraction operator ^(Fraction left, int degree)
        {
            return Pow(left, degree);
        }

        private static BigInteger Sqrt(BigInteger integer)
        {
            if (integer < 0) throw new ArgumentException();
            BigInteger x = 1;
            // const double EPS = 1e-10;
            while (true)
            {
                BigInteger nextX = (x + integer / x) / 2;
                
                if (BigInteger.Abs(x - nextX) == 0) break;
                x = nextX;
            }

            return x;
        }

        public static Fraction Sqrt(Fraction frac)
        {
            return new Fraction(Sqrt(frac.up), Sqrt(frac.down));
        }

        public override string ToString()
        {
            return up.ToString() + "/" + down.ToString();
        }

        public object Clone()
        {
            return new Fraction(up, down);
        }


        public string ToDecimalString(int signs)
        {
            StringBuilder sb = new StringBuilder();
            BigInteger remainder = up;
            sb.Append(BigInteger.Divide(remainder, down));
            remainder = BigInteger.Remainder(remainder, down);
            sb.Append(",");
            
            for (int i = 0; i < signs; i++)
            {
                if (remainder < down)
                {
                    remainder *= 10;
                }
                sb.Append(remainder / down);
                remainder = BigInteger.Remainder(remainder, down);
                
            }

            return sb.ToString();
        }

        

        public bool Equals(Fraction other)
        {
            if (other is null ) return false;
            return up.Equals(other.up) && down.Equals(other.down);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fraction) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(up, down);
        }

        public int CompareTo(Fraction other)
        {
            if (other is null) throw new ArgumentNullException();
            Fraction left = this;
            Fraction right = other;
            left.up *= right.down;
            left.down *= right.down;
            right.up *= left.down;
            right.down *= left.down;

            if (left.up > right.up) return 1;
            if (left.up < right.up) return -1;
            return 0;
        }
        
        public int CompareTo(object obj)
        {
            if (obj is null) throw new ArgumentNullException();
            if (obj is Fraction)
            {
                return CompareTo((Fraction) obj);
            }

            throw new ArgumentException();
        }

        public static bool operator ==(Fraction left, Fraction right)
        {
            if (left is null && right is null) return true;
            if (left is null && right is Fraction)
            {
                return right.Equals(left);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }

        public static bool operator >(Fraction left, Fraction right)
        {
            if (left.CompareTo(right) == 1) return true;
            return false;
        }

        public static bool operator <(Fraction left, Fraction right)
        {
            if (left.CompareTo(right) == -1) return true;
            return false;
        }
    }
}