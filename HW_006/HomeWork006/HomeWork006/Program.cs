using System;
namespace HomeWork006

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction fract1 = new Fraction(3, 4);
            Fraction fract2 = new Fraction(2, 5);

            Console.WriteLine(fract1);
            Console.WriteLine(fract2);

            Fraction sum = fract1 + fract2;
            Console.WriteLine($"Sum: {sum}");

            Fraction difference = fract1 - fract2;
            Console.WriteLine($"Difference: {difference}");

            Fraction product = fract1 * fract2;
            Console.WriteLine($"Product: {product}");

            Fraction quotient = fract1 / fract2;
            Console.WriteLine($"Quotient: {quotient}");

            Console.WriteLine($"fract1 == fract2: {fract1 == fract2}");

            Console.WriteLine($"fract1 != fract2: {fract1 != fract2}");

            Console.WriteLine($"fract1 > fract2: {fract1 > fract2}");

            Console.WriteLine($"fract1 < fract2: {fract1 < fract2}");

            Fraction f3 = fract1++;
            Console.WriteLine($"fraction++: {f3}");

            Fraction f4 = --fract2;
            Console.WriteLine($"--fraction: {f4}");

            
        }
    }
    }






