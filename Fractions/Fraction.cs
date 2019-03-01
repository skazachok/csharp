using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public class Fraction
    {
        public static readonly Fraction Zero = new Fraction(0, 1);

        public Fraction(int numerator, int denominator)
        {
            if(denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be 0."); 
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get; private set;  }
        public int Denominator { get; private set; }

        //public double Ratio => Numerator / Denominator;

        public double Ratio
        {
            get
            {
                return (double)Numerator / Denominator;
            }
        }

        public Fraction Reciprocal
        {
            get
            {
                return new Fraction(Denominator, Numerator);
            }
        }
        public Fraction Negative => new Fraction(-Numerator, Denominator);
        //{
            //get
            //{
                //return new Fraction(-Numerator, Denominator);
            //}
        //}

        public Fraction Multiply(Fraction other)
        {
            return new Fraction(Numerator * other.Numerator, Denominator * other.Denominator);
        }

        public Fraction Add(Fraction other)
        {
            int lcd = LeastCommonDenominator(Denominator, other.Denominator);
            int x = lcd / Denominator, y = lcd / other.Denominator;
            int num = x * Numerator + y * other.Numerator;
            return new Fraction(num, lcd);
        }
        public Fraction Subtract(Fraction other) => Add(other.Negative);

        public Fraction Divide(Fraction other) => Multiply(other.Reciprocal);

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
        public static Fraction operator + (Fraction left, Fraction right)
        {
            return left.Add(right);
        }

        public static Fraction operator - (Fraction left, Fraction right)
        {
            return left.Subtract(right);
        }
        public static Fraction operator * (Fraction left, Fraction right)
        {
            return left.Multiply(right);
        }
        public static Fraction operator / (Fraction left, Fraction right)
        {
            return left.Divide(right);
        }

        public static implicit operator double (Fraction f) => f.Ratio;

        private static int LeastCommonDenominator(int a, int b)
        {
            int num1, num2;
            if(a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }
            for (int i = 1; i < num2; i++)
            {
                if((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num1 * num2;
        }
    }
}
