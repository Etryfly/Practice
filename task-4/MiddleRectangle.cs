using System.Numerics;
using task_1;

namespace task_4
{
    public class MiddleRectangle : IIntegrable
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
            Fraction x;
            Fraction sum = new Fraction(0);
            for (int i = 0; i < n; i++)
            {
                x = left + (i * h);
                sum += func(x + (h/2));
            }

            return sum * h;
        }

        public string IntegrateMethod { get; set; } = "MiddleRectangle";
    }
}