using System.Numerics;
using task_1;

namespace task_4
{
    public class RightRectagnle : IIntegrable
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
            Fraction x;
            Fraction sum = new Fraction(0);
            for (int i = 1; i <= n; i++)
            {
                x = left + i * h;
                sum += func(x);
            }

            return sum * h;
        }

        public string IntegrateMethod { get; set; } = "RightRectangle";
    }
}