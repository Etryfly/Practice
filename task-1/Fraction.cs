using System;
using System.Data;
using System.Numerics;
using System.Text;

namespace task_1
{
    public class Fraction : IEquatable<Fraction>, IComparable<Fraction>, IComparable, ICloneable
    {
        public BigInteger Up { get; private set; }
        public BigInteger Down { get; private set; }
        
        
        public Fraction(BigInteger up, BigInteger down)
        {
            Down = down;
            Up = up;
            
            if (down == 0) throw new ArgumentException("Деление на 0");
            BigInteger gcd = Gcd(up, down);
            Up /= gcd;
            Down /= gcd;
        }

        public static Fraction Simplify(Fraction frac)
        {
            BigInteger gcd = Fraction.Gcd(frac.Up, frac.Down);
            return new Fraction(frac.Up / gcd, frac.Down / gcd);
        }

        // public static Fraction Cut(Fraction frac, Fraction eps)
        // {
        //    
        //     Fraction n = frac;
        //     while (true)
        //     {
        //         if (n.Down / 10 == 0) return n;
        //         if (Abs(n - frac) > eps) return n;
        //         n = new Fraction(n.Up / n.Down, n.Down / 10);
        //         
        //     }
        //     
        // }

        public Fraction(BigInteger up)
        {
            Down = 1;
            this.Up = up;
            
        }
        
        public object Clone()
        {
            return new Fraction(Up, Down);
        }
        
        #region Arithmetic

        private static BigInteger Gcd(BigInteger a, BigInteger b)
        {
            a = BigInteger.Abs(a);
            b = BigInteger.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
            
        }
        public static Fraction Sum(Fraction left, Fraction right)
        {
            return new Fraction(left.Up * right.Down + left.Down * right.Up, left.Down * right.Down);
        }

        private static BigInteger Factorial(BigInteger n)
        {

            if (n <= 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);

        }
        

        public static Fraction Sin(Fraction frac, int precision)
        {
            Fraction result = (Fraction) frac.Clone();
            for (int i = 2; i <= precision; ++i)
            {
                
                result += ((BigInteger.Pow(-1,(i+1))*(frac^(2*i-1)))/Fraction.Factorial(2*i-1));
            }

            return result;
        }
        
        public static Fraction Cos(Fraction frac, int precision)
        {
            Fraction result = new Fraction(1);
            for (int i = 1; i <= precision; ++i)
            {
                
                result += ((BigInteger.Pow(-1,i)*(frac^(2*i)))/Fraction.Factorial(2*i));
            }
            
            return result;
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            return Sum(left, right);
        }

        public static Fraction Subtraction(Fraction left, Fraction right)
        {
            Fraction nR = (Fraction) right.Clone();
            nR.Up *= -1;
            return Sum(left, nR );
        }
        
        public static Fraction operator -(Fraction left, Fraction right)
        {
            return Subtraction(left, right);
        }

        public static Fraction Multiply(Fraction left, Fraction right)
        {
            return new Fraction(left.Up * right.Up, left.Down * right.Down);
        }
        
        public static Fraction operator *(Fraction left, Fraction right)
        {
            return Multiply(left, right);
        }
        
        public static Fraction Division(Fraction left, Fraction right)
        {
            
            
            if (right.Up == 0) throw new ArgumentException();
            BigInteger up = right.Down;
            BigInteger down = right.Up;
            return left * new Fraction(up, down);
        }
        
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return Division(left, right);
        }
        
        public static Fraction Pow(Fraction left, BigInteger degree)
        {
            Fraction result = (Fraction)left.Clone();
            for (BigInteger i = 0; i < degree-1; i++)
            {
                result.Up *= left.Up;
                result.Down *= left.Down;
            }

            return result;
        }
        
        public static Fraction operator ^(Fraction left, BigInteger degree)
        {
            return Pow(left, degree);
        }
        
        public static Fraction operator *(Fraction left, BigInteger right)
        {
            return Multiply(left, new Fraction(right));
        }
        
        public static Fraction operator *(BigInteger right, Fraction left)
        {
            return Multiply(left, new Fraction(right));
        }
        
        public static Fraction operator /( Fraction left, BigInteger right)
        {
            return Division(left, new Fraction(right));
        }

        public static Fraction Abs(Fraction frac)
        {
            if (frac.Up < 0) return new Fraction(frac.Up * (-1), frac.Down);
            return frac;
        }

        public static Fraction Sqrt(Fraction frac, Fraction eps, int degree = 2)
        {
            
            if (frac < new Fraction(0, 1)) throw new ArgumentException(nameof(frac));
            

            Fraction x = (Fraction) frac.Clone();
            BigInteger i = 0;
            while (true)
            {
                Fraction nextX = (x*(degree-1) + (frac / (x^(degree-1)))) / degree;
                nextX = Fraction.Simplify(nextX);
                // nextX = Fraction.Cut(nextX, eps);
                if (Abs(x - nextX) < eps) break;
                x = nextX;
                ++i;
                if (i > 1000000) throw new EvaluateException("Too long calculating sqrt");
            }

            return x;
        }

        public static Fraction Arctan(Fraction frac, int count)
        {
            Fraction PId2 = (new Fraction(245850922,78256779))/2;
            if (frac >= new Fraction(1))
            {
                Fraction result = PId2;
                for (int i = 0; i <= count; ++i)
                {
                    result -= BigInteger.Pow(-1, i) / ((2 * i + 1) * (frac ^ (2 * i + 1)));
                }

                return result;
            } 
            if (frac <= new Fraction(-1))
            {
                Fraction result = -1*PId2;
                for (int i = 0; i <= count; ++i)
                {
                    result -= BigInteger.Pow(-1, i) / ((2 * i + 1) * frac ^ (2 * i + 1));
                }

                return result;
            }
            else
            {
                Fraction result = (Fraction) frac.Clone();
                // Fraction result = new Fraction(0);
                for (int i = 1; i <= count; ++i)
                {
                    result += ((BigInteger.Pow(-1, i) * (frac ^ (2 * i + 1))) / (2 * i + 1));
                }

                return result;
            }
        }
        
        public static Fraction operator /(BigInteger left, Fraction right)
        {
            return Division(new Fraction(left), right);
        }
        
        public static Fraction operator -(Fraction left, BigInteger right)
        {
            return Subtraction(left, new Fraction(right));
        }
        
        public static Fraction operator +(Fraction left, BigInteger right)
        {
            return Sum(left, new Fraction(right));
        }
        

       #endregion

        

        #region String

        public override string ToString()
        {
            return Up.ToString() + "/" + Down.ToString();
        }
        public string ToDecimalString(int signs)
        {
            StringBuilder sb = new StringBuilder();
            bool sgn = Up > 0;
            BigInteger remainder = Up;

            if (!sgn)
            {
                remainder *= -1;
                sb.Append("-");
            }

            sb.Append(BigInteger.Divide(remainder, Down));
            remainder = BigInteger.Remainder(remainder, Down);
            sb.Append(",");
            
            for (int i = 0; i < signs; i++)
            {
                if (remainder < Down)
                {
                    remainder *= 10;
                }
                sb.Append(remainder / Down);
                remainder = BigInteger.Remainder(remainder, Down);
                
            }

            return sb.ToString();
        }

        #endregion

        #region Equals
        public bool Equals(Fraction other)
        {
            if (other is null ) return false;
            return Up.Equals(other.Up) && Down.Equals(other.Down);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fraction) obj);
        }
        
        #endregion
        
        #region Compare
        public override int GetHashCode()
        {
            return HashCode.Combine(Up, Down);
        }

        public int CompareTo(Fraction other)
        {
            if (other is null) throw new ArgumentNullException();
            Fraction left = (Fraction) Clone();
            Fraction right = (Fraction) other.Clone();
            left.Up *= other.Down;
            left.Down *= other.Down;
            right.Up *= this.Down;
            right.Down *= this.Down;

            if (left.Up > right.Up) return 1;
            if (left.Up < right.Up) return -1;
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
        
        public static bool operator <=(Fraction left, Fraction right)
        {
            if (left.CompareTo(right) == -1 || left.CompareTo(right) == 0) return true;
            return false;
        }

        public static bool operator >=(Fraction left, Fraction right)
        {
            if (left.CompareTo(right) == 1 || left.CompareTo(right) == 0) return true;
            return false;
        }

        #endregion
    }
}