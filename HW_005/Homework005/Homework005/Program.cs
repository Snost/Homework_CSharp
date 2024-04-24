using System;
namespace Homework005;
class Program
{

    static void Main(string[] args)
    {

        //1
        try
        {

            ForeignPassport passport = new ForeignPassport("CV123456", "Harry Potter Potterovich", new DateTime(2012, 07, 06));

            Console.WriteLine("Passport number: " + passport.PassportNumber);
            Console.WriteLine("Name of the owner: " + passport.OwnerName);
            Console.WriteLine("Date of issue: " + passport.IssueDate.ToString("dd.MM.yyyy"));
        }
        catch (ArgumentException ex)
        {

            Console.WriteLine("Error: " + ex.Message);
        }

        //2

        Console.WriteLine("Enter an expression separated by a space(12 > 2)");
        string input = Console.ReadLine();

        try
        {
            bool result = CheckExpression(input);
            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static bool CheckExpression(string input)
    {
        string[] parts = input.Split(' ');

        if (parts.Length != 3)
        {
            throw new FormatException("Incorrect format entered");
        }

        int num1 = int.Parse(parts[0]);
        string op = parts[1];
        int num2 = int.Parse(parts[2]);

        switch (op)
        {
            case "==":
                return num1 == num2;
            case "!=":
                return num1 != num2;
            case ">":
                return num1 > num2;
            case "<":
                return num1 < num2;
            case ">=":
                return num1 >= num2;
            case "<=":
                return num1 <= num2;
            default:
                throw new ArgumentException("Unknown operator");
        }
    }
}
