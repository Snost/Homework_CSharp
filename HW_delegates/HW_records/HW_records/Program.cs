namespace HW_records
{
    internal class Program
    {
        //Завдання 5
        //Створіть метод розширення для фільтрації елементів масиву цілих на основі переданого аргументу(предикат
        //визначення умови). Метод повертає новий, створений масив після фільтрації.Наприклад, умовою може бути
        //предикат для перевірки на парність або непарність елементів масиву.

        static int[] Filter(int[] arr, Func<int, bool> predicate)
        {
            int count = 0;
            int index = 0;

            foreach (var item in arr)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            int[] result = new int[count];

            foreach (var item in arr)
            {
                if (predicate(item))
                {
                    result[index++] = item;
                }
            }
            return result;
        }
        //Завдання 6
        //Створіть запис «Денна температура». Необхідно зберігати інформацію про найвищу і найнижчу температуру
        //за день.Створіть масив температур.Напишіть код для обчислення дня з максимальною різницею між найвищою
        //і найнижчою температурою
        public record DayTemperature(double High, double Low)
        {
            public double TemperatureDifference => High - Low;
        }

        static void Main(string[] args)

        {
            Console.WriteLine("--------------TASK 5---------------");
            int[] arr = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            int[] eNum = Filter(arr, n => n % 2 == 0);
            int[] oddNum = Filter(arr, n => n % 2 != 0);

            Console.WriteLine($"Even numbers - {string.Join(", ", eNum)}") ;
            Console.WriteLine($"Odd numbers - {string.Join(", ", oddNum)}");

            Console.WriteLine("--------------TASK 6---------------");

            DayTemperature[] weekTemp = new DayTemperature[]
        {
            new DayTemperature(26.0, 14.0),
            new DayTemperature(27.0, 13.0),
            new DayTemperature(27.0, 14.5),
            new DayTemperature(24.0, 12.0),
            new DayTemperature(26.5, 11.0),
            new DayTemperature(26.0, 12.0),
            new DayTemperature(24.0, 13.5)
        };

            var maxDiffDay = weekTemp .Select((temp, index) => new { Temp = temp, Day = index + 1 })
                .OrderByDescending(x => x.Temp.TemperatureDifference)
                .First();

            Console.WriteLine($"Day with maximum temperature difference: {maxDiffDay.Day} Day");
            Console.WriteLine($"Max and min temperature: {maxDiffDay.Temp.High} - {maxDiffDay.Temp.Low}°С");
            Console.WriteLine($"Temperature difference: {maxDiffDay.Temp.TemperatureDifference}°С");
        }
    }

        
    }

    

