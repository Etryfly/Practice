using System.Numerics;
using task_1;

namespace task_4
{
    public class Simpson : IIntegrable
    {
        public Fraction Integrate(IIntegrable.Function func, Fraction left, Fraction right, Fraction eps)
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
                sum += (x2 - x1) / 6 * (func(x1) + 4 * func((x1 + x2)/2) + func(x2));
            }

            return sum;
        }

        public string IntegrateMethod { get; set; } = "Trapeze";
    }
}