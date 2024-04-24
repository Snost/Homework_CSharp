using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()

    {//5
        try
        {
            Console.WriteLine("Enter an arithmetic expression with + and -:");
            string expression = Console.ReadLine();

            string[] parts = expression.Split(new char[] { '+', '-' });

            int result = int.Parse(parts[0]);

            for (int i = 1; i < parts.Length; i++)
            {
                char ch = expression[expression.IndexOf(parts[i]) - 1];

                int op = int.Parse(parts[i]);

                if (ch == '+')
                {
                    result += op;
                }
                else if (ch == '-')
                {
                    result -= op;
                }
            }

            Console.WriteLine("Result: " + result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter + or - ");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.ReadLine();


        //6
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        string[] str = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        string[] op = new string[str.Length];
        for (int i = 0; i < op.Length; i++)
        {
            int indexOp = text.IndexOf(str[i]) + str[i].Length;
            if (indexOp < text.Length)
                op[i] = text.Substring(indexOp, 1);
        }

        for (int i = 0; i < str.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(str[i]))
            {
                str[i] = str[i].Trim();

                if (str[i].Length > 0 && char.IsLower(str[i][0]))
                {
                    str[i] = char.ToUpper(str[i][0]) + str[i].Substring(1);
                }
            }
        }

        string result = "";
        for (int i = 0; i < str.Length; i++)
        {
            result += str[i] + (i < op.Length ? op[i] : "") + " ";
        }

        Console.WriteLine("Result:");
        Console.WriteLine(result);
        Console.ReadLine();

        //7
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        string[] forbiddenWords = { "die", "kill", "knife", "death" };

        int[] forbiddenWordCounts = new int[forbiddenWords.Length];

        char[] delimiters = { ' ', '.', ',', '!', '?', ':', ';' };
        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            string cleanedWord = words[i];
            foreach (char delimiter in delimiters)
            {
                cleanedWord = cleanedWord.Trim(delimiter);
            }
            for (int j = 0; j < forbiddenWords.Length; j++)
            {
                if (cleanedWord.Equals(forbiddenWords[j]))
                {
                    words[i] = new string('*', words[i].Length);
                    forbiddenWordCounts[j]++;
                }
            }
        }

        string result = string.Join(" ", words);

        Console.WriteLine("Result:");
        Console.WriteLine(result);

        Console.WriteLine("Statistics:");
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            Console.WriteLine($"Replaced {forbiddenWords[i]} - {forbiddenWordCounts[i]} times");
        }
        Console.ReadLine();
    }
}
    
