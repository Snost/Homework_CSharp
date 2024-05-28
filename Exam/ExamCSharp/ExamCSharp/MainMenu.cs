using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace ExamCSharp
{
    class MainMenu
    {
        private static string currentUser;
        private static Dictionary<string, (string Password, DateTime BirthDate)> users;
        public static void Show(string user)
        {
            currentUser = user;
            bool exit = false;
            string[] mainMenu = { "  Main Menu  ", "Start", "Result", "Settings", "Exit" };

            int selectedIndex = 1;
            while (!exit)
            {
                Console.Clear();
                MenuPrinter.PrintCenteredMenu(mainMenu, selectedIndex);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 1) ? mainMenu.Length - 1 : selectedIndex - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == mainMenu.Length - 1) ? 1 : selectedIndex + 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (mainMenu[selectedIndex])
                    {
                        case "Start":
                            StartQuiz();
                            break;
                        case "Result":
                            ShowResults();
                            break;
                        case "Settings":
                            ShowSettings();
                            break;
                        case "Exit":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            Thread.Sleep(1000);
                            break;
                    }
                }
            }
        }
      
            private static void ShowResults()
            {
            ResultManager.Show(currentUser);
            }


        private static void StartQuiz()
        {
            QuizManager.Show(currentUser);
        }

        private static void ShowSettings()
        {
            SettingsOption.Show(currentUser);
        }

    }
}



