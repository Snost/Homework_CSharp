using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharp
{
    class LoadingScreen
    {
        public void Show()
        {
            Random random = new Random();

            int startTime = Environment.TickCount; 

            while (Environment.TickCount - startTime < 3000)
            {
                int x = random.Next(Console.WindowWidth);
                int y = random.Next(Console.WindowHeight);

                Console.SetCursorPosition(x, y);

                if (random.Next(2) == 0)
                {
                    Console.ForegroundColor = (ConsoleColor)random.Next(0, 16);
                    char randomLetter = (char)('a' + random.Next(0, 26));
                    Console.Write(randomLetter);
                    Thread.Sleep(20);
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write(" ");
                    Thread.Sleep(20);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;

                string[] letters = {
            "QQQQQ   U   U  IIIII  ZZZZZZZ",
            "Q   Q   U   U    I          Z",
            "Q   Q   U   U    I         Z",
            "Q   Q   U   U    I        Z",
            "Q   Q   U   U    I       Z",
            "Q Q Q   U   U    I      Z",
            "Q  QQ   U   U    I     Z",
            "QQQQQ    UUU   IIIII  ZZZZZZZ",
            "     Q                       "
        };
                int textWidth = letters[0].Length;
                int textHeight = letters.Length;
                int centerX = (Console.WindowWidth - textWidth) / 2;
                int centerY = (Console.WindowHeight - textHeight) / 2;

                Console.SetCursorPosition(centerX, centerY - 1);
                for (int i = 0; i < letters.Length; ++i)
                {
                    string line = letters[i];
                    Console.WriteLine($"{line}");
                    Console.SetCursorPosition(centerX, centerY + i);

                }


                Console.SetCursorPosition(centerX, centerY + 10);
                for (int i = 0; i < (Environment.TickCount - startTime) / 100 + 1; i++)
                {
                    Console.Write('\u2593');

                }

                Console.ResetColor();
            }
        }
    }
}
