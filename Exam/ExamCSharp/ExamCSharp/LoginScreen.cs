using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExamCSharp
{
    public class LoginScreen
    {
        public static string FilePath { get; } = "users.txt";
        private Dictionary<string, (string Password, DateTime BirthDate)> users = new Dictionary<string, (string Password, DateTime BirthDate)>();

        public Dictionary<string, (string Password, DateTime BirthDate)> GetUsers()
        {
            return users;
        }


        public string CurrentUser { get; private set; }

        public LoginScreen()
        {
            LoadUsers();
        }

       
        public bool Run()
        {
            LoadUsers();

            
            if (ShowMenu())
            {
                Console.WriteLine("Login successful!");
                MainMenu.Show(CurrentUser);
                if (!Directory.Exists(CurrentUser))
                {
                    Directory.CreateDirectory(CurrentUser);
                }
                return true;

                
            }
            else
            {
                return false;
            }

        }


        private void LoadUsers()
        {
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3 && DateTime.TryParse(parts[2], out DateTime birthDate))
                    {
                        users[parts[0]] = (parts[1], birthDate);
                    }
                }
            }
        }

        private void SaveUsers()
        {
            var lines = users.Select(x => $"{x.Key},{x.Value.Password},{x.Value.BirthDate:yyyy-MM-dd}");
            File.WriteAllLines(FilePath, lines);
        }

        private bool ShowMenu()
        {
            string[] options = { "Login", "Register", "Exit" };
            int selectedIndex = 0;
            while (true)
            {
                Console.Clear();
                MenuPrinter.PrintCenteredMenu(options, selectedIndex);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (options[selectedIndex] == "Login")
                    {
                        return ShowLogin();
                    }
                    else if (options[selectedIndex] == "Register")
                    {
                        if (ShowRegister())
                        {
                            return true;
                        }
                    }
                    else if (options[selectedIndex] == "Exit")
                    {
                        return false;
                    }
                }
            }
        }

        private bool ShowLogin()
        {
            int attempt = 4;
            while (attempt != 0)
            {
                Console.Clear();
                string[] loginText = {
                    "======= Login =======",
                    "Username: ",
                    "Password: ",
                    "====================="
                };

                MenuPrinter.PrintCenteredText(loginText);

                Console.SetCursorPosition((Console.WindowWidth - "Username: ".Length) / 2 + 4, Console.CursorTop - 3);
                string username = Console.ReadLine();

                Console.SetCursorPosition((Console.WindowWidth - "Password: ".Length) / 2 + 4, Console.CursorTop);
                string password = Console.ReadLine();

                if (users != null && users.ContainsKey(username))
                {
                    var storedPassword = users[username].Password;

                    if (password == storedPassword)
                    {
                        Console.Clear();
                        MenuPrinter.PrintCenteredText(new[] { "Login successful!" });
                        Console.ReadLine();
                        CurrentUser = username;
                        return true;
                    }
                    else
                    {
                        attempt--;
                        Console.Clear();
                        MenuPrinter.PrintCenteredText(new[] { $"Login failed. You have {attempt} attempts left." });
                        Console.ReadLine();
                    }
                }
                else
                {
                    attempt--;
                    Console.Clear();
                    MenuPrinter.PrintCenteredText(new[] { $"Login failed. You have {attempt} attempts left." });
                    Console.ReadLine();
                }
            }
            return false;
        }

        private bool ShowRegister()
        {
            int attempt = 2;
            do
            {
                Console.Clear();
                string[] registerText = {
                    "======= Register =======",
                    "Username: ",
                    "Password: ",
                    "Birth Date: ",
                    "========================"
                };

                MenuPrinter.PrintCenteredText(registerText);

                Console.SetCursorPosition((Console.WindowWidth - "Username: ".Length) / 2 + 3, Console.CursorTop - 4);
                string username = Console.ReadLine();

                Console.SetCursorPosition((Console.WindowWidth - "Password: ".Length) / 2 + 3, Console.CursorTop);
                string password = Console.ReadLine();

                if (!UserInputValidator.ValidatePassword(password))
                {
                    Console.Clear();
                    MenuPrinter.PrintCenteredText(new[] { "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one number." });
                    Console.ReadKey();
                    continue;
                }

                Console.SetCursorPosition((Console.WindowWidth - "Birth Date: ".Length) / 2 + 6, Console.CursorTop);
                string birthDateString = Console.ReadLine();

                if (!DateTime.TryParse(birthDateString, out DateTime birthDate))
                {
                    Console.Clear();
                    MenuPrinter.PrintCenteredText(new[] { "Invalid birth date format. Please use yyyy-MM-dd." });
                    Console.ReadKey();
                    continue;
                }

                if (!users.ContainsKey(username))
                {
                    users[username] = (password, birthDate);
                    SaveUsers();
                    Console.Clear();
                    MenuPrinter.PrintCenteredText(new[] { "User registered successfully!" });
                    Console.ReadKey();
                    CurrentUser = username;
                    return true;
                }
                else
                {
                    Console.Clear();
                    MenuPrinter.PrintCenteredText(new[] { "Username already exists." });
                    Console.ReadKey();
                    attempt--;
                }

            } while (attempt > 0);

            Console.Clear();
            MenuPrinter.PrintCenteredText(new[] { "Too many attempts!" });
            Console.ReadKey();
            return false;
        }
        

        public void ChangeUserPassword(string username, string newPassword)
        {
            if (users.ContainsKey(username))
            {
                users[username] = (newPassword, users[username].BirthDate);
                SaveUsers();
            }
        }

        public void ChangeUserBirthDate(string username, DateTime newBirthDate)
        {
            if (users.ContainsKey(username))
            {
                users[username] = (users[username].Password, newBirthDate);
                SaveUsers();
            }
        }


    }
}
