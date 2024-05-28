using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ExamCSharp
{
    class SettingsOption
    {
        public static void Show(string currentUser)
        {
            bool exit = false;
            string[] settingsOptions = { "Change Password", "Change Birth Date", "Create Quiz", "Edit Quiz", "Back" };
            int selectedIndex = 0;

            while (!exit)
            {
                Console.Clear();
                MenuPrinter.PrintCenteredMenu(settingsOptions, selectedIndex);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? settingsOptions.Length - 1 : selectedIndex - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == settingsOptions.Length - 1) ? 0 : selectedIndex + 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (settingsOptions[selectedIndex])
                    {
                        case "Change Password":
                            ChangePassword(currentUser);
                            break;
                        case "Change Birth Date":
                            ChangeBirthDate(currentUser);
                            break;
                        case "Create Quiz":
                            CreateQuiz();
                            break;
                        case "Edit Quiz":
                            EditQuiz();
                            break;
                        case "Back":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid selection!");
                            Thread.Sleep(1000);
                            break;
                    }
                }
            }
        }

        private static void Log(string message)
        {
            Logger.Log(message);
        }

        private static void ChangePassword(string currentUser)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter new password:");
                string newPassword = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newPassword) || !UserInputValidator.ValidatePassword(newPassword))
                {
                    Console.Clear();
                    MenuPrinter.PrintCenteredText(new[] { "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one number." });
                    Console.ReadKey();
                }
                else
                {
                    LoginScreen loginScreen = new LoginScreen();
                    loginScreen.ChangeUserPassword(currentUser, newPassword);

                    Console.WriteLine("Password changed successfully! ");
                    Console.ReadKey();

                    Log($"Password changed for user: {currentUser}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing password: {ex.Message}");
                Log($"Error changing password: {ex.Message}");
                Console.ReadKey();
            }
        }

        private static void ChangeBirthDate(string currentUser)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter new birth date (yyyy-MM-dd):");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime newBirthDate))
                {
                    LoginScreen loginScreen = new LoginScreen();
                    loginScreen.ChangeUserBirthDate(currentUser, newBirthDate);

                    Console.WriteLine("Birth date changed successfully! ");
                    Log($"Birth date changed for user: {currentUser}");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Press any key to return to settings.");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing birth date: {ex.Message}");
                Log($"Error changing birth date: {ex.Message}");
                Console.ReadKey();
            }
        }

        public static void CreateQuiz()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the category for the new quiz:");
                string category = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(category))
                {
                    Console.WriteLine("Category cannot be empty! ");
                    Console.ReadKey();
                    return;
                }

                string filePath = $"{category.ToLower()}_questions.json";
                List<Question> questions = File.Exists(filePath) ? QuizManager.LoadQuestionsFromFile(filePath) : new List<Question>();

                bool addMoreQuestions = true;
                while (addMoreQuestions)
                {
                    Question question = new Question();

                    Console.WriteLine("Enter the question:");
                    question.Text = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(question.Text))
                    {
                        Console.WriteLine("Question text cannot be empty. ");
                        Console.ReadKey();
                        continue;
                    }

                    question.Options = new List<string>();
                    Console.WriteLine("Enter options (Enter 'DONE' to finish adding options):");

                    while (true)
                    {
                        string option = Console.ReadLine();
                        if (option.ToUpper() == "DONE")
                        {
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(option))
                        {
                            Console.WriteLine("Option text cannot be empty. Please enter a valid option.");
                        }
                        else
                        {
                            question.Options.Add(option);
                        }
                    }

                    Console.WriteLine("Enter correct index/indices (comma-separated):");
                    string[] correctIndexStrings = Console.ReadLine().Split(',');

                    question.CorrectIndexes = new List<int>();
                    foreach (var indexString in correctIndexStrings)
                    {
                        if (int.TryParse(indexString, out int index))
                        {
                            question.CorrectIndexes.Add(index);
                        }
                    }

                    Console.WriteLine("Is it a single answer question? (Y/N):");
                    question.IsSingleAnswer = Console.ReadLine().ToUpper() == "Y";

                    if (!UserInputValidator.ValidateQuestion(question))

                    {
                        Console.WriteLine("Invalid question data");
                        Log($"Error creating quiz!Invalid question data!");
                        Console.Clear();
                        Console.ReadKey();
                        continue;
                    }

                    questions.Add(question);

                    Console.WriteLine("Add another question? (Y/N):");
                    addMoreQuestions = Console.ReadLine().ToUpper() == "Y";
                }

                QuizManager.SaveQuestionsToFile(category, questions);

                Console.WriteLine("Quiz created successfully! ");
                Log($"Quiz created successfully for category: {category}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating quiz: {ex.Message}");
                Log($"Error creating quiz: {ex.Message}");
                Console.ReadKey();
            }
        }

       

        public static void EditQuiz()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Select a category to edit:");
                string[] categories = QuizManager.GetQuizCategories();
                int categoryIndex = MenuPrinter.DisplayMenuAndGetSelection(categories);

                string selectedCategory = categories[categoryIndex];
                string filePath = $"{selectedCategory.ToLower()}_questions.json";

                List<Question> questions = QuizManager.LoadQuestionsFromFile(filePath);

                Console.Clear();
                Console.WriteLine($"Selected category: {selectedCategory}");

                Console.WriteLine("Existing Questions:");
                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {questions[i].Text}");
                }

                Console.WriteLine("Do you want to edit existing questions or add new ones? (E/A/Exit)");
                string editOption = Console.ReadLine().ToUpper();

                if (editOption == "E")
                {
                    Console.WriteLine("Enter the index of the question to edit:");
                    if (int.TryParse(Console.ReadLine(), out int editIndex) && editIndex >= 1 && editIndex <= questions.Count)
                    {
                        Question selectedQuestion = questions[editIndex - 1];

                        Console.WriteLine("Enter the new text for the question:");
                        selectedQuestion.Text = Console.ReadLine();

                        Console.WriteLine("Do you want to edit the options? (Y/N)");
                        string editOptions = Console.ReadLine().ToUpper();
                        if (editOptions == "Y")
                        {
                            for (int i = 0; i < selectedQuestion.Options.Count; i++)
                            {
                                Console.WriteLine($"Enter the new text for option {i + 1}:");
                                selectedQuestion.Options[i] = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("Enter correct index (comma-separated):");
                        string[] correctIndexStrings = Console.ReadLine().Split(',');
                        selectedQuestion.CorrectIndexes = new List<int>();
                        foreach (var indexString in correctIndexStrings)
                        {
                            if (int.TryParse(indexString, out int index))
                            {
                                selectedQuestion.CorrectIndexes.Add(index);
                            }
                        }

                        Console.WriteLine("Is it a single answer question? (Y/N):");
                        selectedQuestion.IsSingleAnswer = Console.ReadLine().ToUpper() == "Y";

                        if (!UserInputValidator.ValidateQuestion(selectedQuestion))

                        {
                            Console.WriteLine("Invalid question data!");

                            Console.ReadKey();
                            
                            return;
                        }

                        QuizManager.SaveQuestionsToFile(selectedCategory, questions);
                        Console.WriteLine("Question updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid index! ");
                        Console.ReadKey();
                    }
                }
                else if (editOption == "A")
                {
                    Question newQuestion = new Question();

                    Console.WriteLine("Enter the question:");
                    newQuestion.Text = Console.ReadLine();

                    newQuestion.Options = new List<string>();
                    Console.WriteLine("Enter options (Enter 'DONE' to finish adding options):");
                    while (true)
                    {
                        string option = Console.ReadLine();
                        if (option.ToUpper() == "DONE")
                        {
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(option))
                        {
                            Console.WriteLine("Option text cannot be empty!");
                        }
                        else
                        {
                            newQuestion.Options.Add(option);
                        }
                    }

                    Console.WriteLine("Enter correct index (comma-separated):");
                    string[] correctIndexStrings = Console.ReadLine().Split(',');
                    newQuestion.CorrectIndexes = new List<int>();
                    foreach (var indexString in correctIndexStrings)
                    {
                        if (int.TryParse(indexString, out int index))
                        {
                            newQuestion.CorrectIndexes.Add(index);
                        }
                    }

                    Console.WriteLine("Is it a single answer question? (Y/N):");
                    newQuestion.IsSingleAnswer = Console.ReadLine().ToUpper() == "Y";

                   if (!UserInputValidator.ValidateQuestion(newQuestion)) { 

                        Console.WriteLine("Invalid question data!");
                        Log($"Error editing quiz!Invalid question data!");
                        Console.ReadKey();
                        return;
                    }

                    questions.Add(newQuestion);

                    QuizManager.SaveQuestionsToFile(selectedCategory, questions);
                    Console.WriteLine("New question added successfully!");
                }
                else if (editOption == "EXIT")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option! ");
                    Console.ReadKey();
                }

                Console.WriteLine("Exit to main menu...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editing quiz: {ex.Message}");
                Log($"Error editing quiz: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
