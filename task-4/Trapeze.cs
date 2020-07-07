using System.Numerics;
using task_1;

namespace task_4
{
    public class Trapeze : IIntegrable
    {
        public Fraction Integrate(IIntegrable.Function func, Fraction left, Fraction right, Fraction eps, out BigInteger n)
        {
            BigInteger N = 1;
            Fraction prevY = Integrate(func, left, right, N);
            Fraction Y;
            while (true)
            {
                N++;
                Y = Integrate(func, left, right, N);
                if (Fraction.Abs(Y - prevY) < eps) break;
                prevY = Y;
                
            }

            n = N;
            return Y;
        }
        
        public Fraction Integrate(IIntegrable.Function func, Fraction left, Fraction right, BigInteger n)
        {
            Fraction h = (right - left) / n;
            Fraction sum = new Fraction(0);
            for (int i = 0; i < n; i++)
            {
                Fraction x1 = left + h * i;
                Fraction x2 = left + h * (i+1);
                sum += (func(x1) + func(x2))* (x2 - x1) / 2;
            }

            return sum;
        }

        public string IntegrateMethod { get; set; } = "Trapeze";
    }
}