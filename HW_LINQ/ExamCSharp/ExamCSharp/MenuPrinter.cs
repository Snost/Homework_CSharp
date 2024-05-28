using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharp
{
    public static class MenuPrinter
    {
        public static int DisplayMenuAndGetSelection(string[] menuItems)
        {
            int selectedIndex = 0;
            bool selectionMade = false;

            while (!selectionMade)
            {
                PrintCenteredMenu(menuItems, selectedIndex);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    selectionMade = true;
                }
            }

            return selectedIndex;
        }
        public static void PrintCenteredMenu(string[] menuItems, int selectedIndex)
        {
            int maxWidth = GetMaxWidth(menuItems) + 4;
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int startX = (windowWidth - maxWidth) / 2;
            int startY = (windowHeight - menuItems.Length - 2) / 2;

           
            Console.SetCursorPosition(startX, startY);
            Console.WriteLine("+" + new string('=', maxWidth - 2) + "+");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i + 1);
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"> {menuItems[i].PadRight(maxWidth - 4)}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {menuItems[i].PadRight(maxWidth - 4)}");
                }
            }

            Console.SetCursorPosition(startX, startY + menuItems.Length + 1);
            Console.WriteLine("+" + new string('=', maxWidth - 2) + "+");
        }

        public static void PrintCenteredText(string[] textLines)
        {
            int maxWidth = GetMaxWidth(textLines);
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int startX = (windowWidth - maxWidth) / 2;
            int startY = (windowHeight - textLines.Length) / 2;

            for (int i = 0; i < textLines.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                Console.WriteLine(textLines[i]);
            }
        }

        private static int GetMaxWidth(string[] lines)
        {
            int maxWidth = 0;
            foreach (string line in lines)
            {
                if (line.Length > maxWidth)
                {
                    maxWidth = line.Length;
                }
            }
            return maxWidth;
        }

    }
}
