using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть арифметичний вираз (з операціями + і -):");
        string expression = Console.ReadLine();

        // Розділити вираз на операнди та оператори
        string[] parts = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

        // Перший операнд
        int result = int.Parse(parts[0]);

        // Пройти по решті операндів та виконати відповідні операції
        for (int i = 1; i < parts.Length; i++)
        {
            // Оператор
            char op = expression[expression.IndexOf(parts[i]) - 1];

            // Операція
            if (op == '+')
            {
                result += int.Parse(parts[i]);
            }
            else if (op == '-')
            {
                result -= int.Parse(parts[i]);
            }
        }

        Console.WriteLine("Результат: " + result);
    }
}
