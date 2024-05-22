using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW_Files
{
    internal class Program
    {
        //Завдання 1:
        //Додаток генерує 100 цілих чисел.Збережіть в один файл усі
        //прості числа, в інший файл усі числа Фібоначчі. Статистику роботи
        //додатку виведіть на екран.

        static List<int> GenerateNum(int count)
        {
            Random random = new Random();
            return Enumerable.Range(1, count).Select(x => random.Next(1, 20)).ToList();
        }

        static bool IsNormal(int num)
        {
            if (num <= 1)
                return false;
            if (num <= 3)
                return true;
            if (num % 2 == 0 || num % 3 == 0)
                return false;
            for (int i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                    return false;
            }
            return true;
        }

        static bool IsFibonacci(int num)
        {
            int a = 0, b = 1;
            while (b < num)
            {
                int temp = b;
                b = a + b;
                a = temp;
            }
            return b == num || num == 0 || num == 1;
        }

        static void WriteToFile(List<int> numb, string fileName)
        {
            File.WriteAllLines(fileName, numb.Select(n => n.ToString()));
        }

        static void Main()
        {
            Console.WriteLine("--------------TASK 1--------------");
            List<int> numb = GenerateNum(100);

            var normalNum = numb.Where(IsNormal).ToList();
            var fibonacciNum = numb.Where(IsFibonacci).ToList();

            WriteToFile(normalNum, "primeNum.txt");
            WriteToFile(fibonacciNum, "fibonacciNum.txt");


            foreach (var num in numb)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine($"Normal number - {normalNum.Count}");
            foreach (var num in normalNum)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Fibonacci numbers - {fibonacciNum.Count}");
            foreach (var num in fibonacciNum)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();


            //            Завдання 2:
            //Користувач вводить з клавіатури слово для пошуку у файлі і
            //слово для заміни.Додаток має змінити усі входження шуканого
            //слова на слово для заміни.Статистику роботи додатку виведіть
            //на екран.
            Console.WriteLine("--------------TASK 2--------------");
            Console.Write("Word to search: ");
            string searchWord = Console.ReadLine();

            Console.Write("Replacement word: ");
            string replaceWord = Console.ReadLine();

            string filename = "text.txt";

            try
            {
                string[] lines = File.ReadAllLines(filename);

                int replaceCount = 0;

                var newLines = lines.Select(line =>
                {
                    int index;
                    while ((index = line.IndexOf(searchWord)) != -1)
                    {
                        replaceCount++;
                        line = line.Remove(index, searchWord.Length).Insert(index, replaceWord);
                    }
                    return line;
                }).ToArray();

                if (replaceCount == 0)
                {
                    throw new InvalidOperationException($"'{searchWord}' not found in file");
                }

                File.WriteAllLines(filename, newLines);

                Console.WriteLine($"Count replacement - {replaceCount}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {filename} not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
            }

            //Завдання 3
            // Створіть додаток «Модератор». Користувач вводить шлях до
            //файлу з текстом і до файлу зі словами для модерації. За
            //підсумками роботи додатка, всі слова для модерації у
            //початковому файлі мають бути замінені на "*".

            Console.WriteLine("--------------TASK 3--------------");
            try
            {
                string filename = "text.txt";
                string filenameMod = "moderation.txt";

                string[] modWords = File.ReadAllLines(filenameMod);
                string[] lines = File.ReadAllLines(filename);

                string[] modLines = lines.Select(line =>
                {
                    string[] words = line.Split(' ');

                    for (int i = 0; i < words.Length; i++)
                    {
                        if (modWords.Contains(words[i]))
                        {
                            words[i] = new string('*', words[i].Length);
                        }
                    }

                    return string.Join(" ", words);
                }).ToArray();

                foreach (string modLine in modLines)
                {
                    Console.WriteLine(modLine);
                }
                File.WriteAllLines(filename, modLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }

        }

    }
}



  