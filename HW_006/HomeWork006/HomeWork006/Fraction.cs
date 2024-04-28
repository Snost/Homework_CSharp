using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeWork006
{
    class Fraction
    {
    private int numerator;
    private int denominator;

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if (denominator != 0)
            this.denominator = denominator;
        else
            throw new ArgumentException("Denominator cannot be 0.");

        Calculate();
    }

    private void Calculate()
    {
        int divisor = Divisor(Math.Abs(numerator), Math.Abs(denominator));
        numerator /= divisor;
        denominator /= divisor;
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
    }

    private int Divisor(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(a.numerator * b.denominator - b.numerator * a.denominator, a.denominator * b.denominator);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
    }

    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.numerator == b.numerator && a.denominator == b.denominator;
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }

    public static bool operator >(Fraction a, Fraction b)
    {
        return (double)a.numerator / a.denominator > (double)b.numerator / b.denominator;
    }

    public static bool operator <(Fraction a, Fraction b)
    {
        return (double)a.numerator / a.denominator < (double)b.numerator / b.denominator;
    }

    public static Fraction operator ++(Fraction a)
    {
        return new Fraction(a.numerator + a.denominator, a.denominator);
    }

    public static Fraction operator --(Fraction a)
    {
        return new Fraction(a.numerator - a.denominator, a.denominator);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Fraction))
            return false;

        Fraction equal = (Fraction)obj;
        return this == equal;
    }

    public override int GetHashCode()
    {
        return numerator.GetHashCode() ^ denominator.GetHashCode();
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    
}
}
