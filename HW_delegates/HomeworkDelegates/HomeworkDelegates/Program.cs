namespace HomeworkDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = { -2,-1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            //Завдання 1
            //Створіть лямбда-вираз для підрахунку кількості чисел у масиві, кратних семи.Напишіть код для тестування
            //роботи лямбди.

            Console.WriteLine("--------------------TASK 1---------------------");
            Func<int[], int> multiSeven = (arr => arr.Count(n => n % 7 == 0));
            Console.WriteLine(multiSeven(arr));

            //Завдання 2
            //Створіть лямбда-вираз для підрахунку кількості позитивних чисел в масиві.Напишіть код для тестування
            //роботи лямбди.
            Console.WriteLine("--------------------TASK 2---------------------");

            Func<int[], int> positiveNum = arr => arr.Count(n => n > 0);
            Console.WriteLine(positiveNum(arr));

            // Завдання 3
            //Створіть лямбда-вираз для відображення унікальних, негативних чисел у масиві. Напишіть код для тестування роботи лямбди.
            Console.WriteLine("--------------------TASK 3---------------------");

            var NegUniqueNum = arr.Where(n => n < 0).Distinct();

            foreach (var num in NegUniqueNum)
            {
                Console.WriteLine(num);
            }
            //Завдання 4
            //Створіть лямбда-вираз для перевірки тексту на задане слово.Напишіть код для тестування роботи лямбди
            Console.WriteLine("--------------------TASK 4---------------------");

            string text = "Hello world!";
            string find = "world";
            Func<string, string, bool> isContain = (txt, word) => txt.Contains(word);
            Console.WriteLine(isContain(text, find));
        }
    }

}
