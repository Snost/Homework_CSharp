using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ExamCSharp
{
    public class QuizManager
    {
        public static void SaveQuestionsToFile(string category, List<Question> questions)
        {
            string filePath = $"{category.ToLower()}_questions.json";
            try
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(questions, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving questions to file: {ex.Message}");
                Logger.Log($"Error saving questions to file: {ex.Message}");
            }
        }

        public static List<Question> LoadQuestionsFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<Question>();
                }

                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Question>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading questions from file: {ex.Message}");
                Logger.Log($"Error loading questions from file: {ex.Message}");
                return new List<Question>();
            }
        }

        public static string[] GetQuizCategories()
        {
            try
            {
                var files = Directory.GetFiles(".", "*_questions.json");
                List<string> categories = new List<string>();

                foreach (var file in files)
                {
                    categories.Add(Path.GetFileNameWithoutExtension(file).Replace("_questions", ""));
                }

                categories.Add("Mixed");

                return categories.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting quiz categories: {ex.Message}");
                Logger.Log($"Error getting quiz categories: {ex.Message}");
                return new string[0];
            }
        }

        public static List<Question> GetRandomMixedQuiz()
        {
            List<Question> mixedQuestions = new List<Question>();

            try
            {
                var categories = GetQuizCategories().Where(c => c != "Mixed");

                foreach (var category in categories)
                {
                    var categoryQuestions = LoadQuestionsFromFile($"{category.ToLower()}_questions.json");
                    mixedQuestions.AddRange(categoryQuestions);
                }

                Random rnd = new Random();
                for (int i = mixedQuestions.Count - 1; i > 0; i--)
                {
                    int j = rnd.Next(0, i + 1);
                    var temp = mixedQuestions[i];
                    mixedQuestions[i] = mixedQuestions[j];
                    mixedQuestions[j] = temp;
                }

                var selectedQuestions = mixedQuestions.Take(20).ToList();

                foreach (var question in selectedQuestions)
                {
                    question.Category = "Mixed";
                }

                return selectedQuestions;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting mixed quiz: {ex.Message}");
                Logger.Log($"Error getting mixed quiz: {ex.Message}");
                return new List<Question>();
            }
        }

        public static void Show(string currentUser)
        {
            try
            {
                Console.Clear();
                string[] categories = QuizManager.GetQuizCategories();
                int selectedIndex = 0;

                while (true)
                {
                    Console.Clear();
                    MenuPrinter.PrintCenteredMenu(categories, selectedIndex);

                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = (selectedIndex == 0) ? categories.Length - 1 : selectedIndex - 1;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex == categories.Length - 1) ? 0 : selectedIndex + 1;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        string selectedCategory = categories[selectedIndex];
                        List<Question> questions = new List<Question>();

                        if (selectedCategory == "Mixed")
                        {
                            questions = QuizManager.GetRandomMixedQuiz();
                        }
                        else
                        {
                            string filePath = $"{selectedCategory.ToLower()}_questions.json";
                            questions = QuizManager.LoadQuestionsFromFile(filePath);

                            foreach (var question in questions)
                            {
                                question.Category = selectedCategory;
                            }
                        }

                        if (questions.Count > 0)
                        {
                            PlayQuiz(questions, currentUser);
                        }
                        else
                        {
                            Console.WriteLine("No quiz available for this category!");
                            Logger.Log("No quiz available for this category!");
                            Console.ReadKey();
                        }
                        break;
                    }
                }

                Logger.Log("Quiz started");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error showing quiz: {ex.Message}");
                Logger.Log($"Error showing quiz: {ex.Message}");
            }
        }

        private static Random random = new Random();

        private static void PlayQuiz(List<Question> questions, string currentUser)
        {
            int score = 0;
            string category = questions.First().Category;

            try
            {
                Console.Clear();

                
                var twentyQuestions = questions.OrderBy(q => random.Next()).ToList();

                // Вибираємо перші 20 запитань або всі, якщо менше 20
                var selectedQuestions = twentyQuestions.Take(20).ToList();

                foreach (var question in selectedQuestions)
                {
                    List<int> selectedIndexes = new List<int>();

                    int selectedIndex = 0;
                    bool isAnswered = false;

                    while (!isAnswered)
                    {
                        Console.Clear();

                        Console.WriteLine(question.Text);

                        Console.WriteLine("Choose the correct options :");

                        for (int i = 0; i < question.Options.Count; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("> ");
                            }
                            else
                            {
                                Console.ResetColor();
                                Console.Write("  ");
                            }

                            Console.WriteLine(question.Options[i]);
                        }

                        Console.ResetColor();

                        var key = Console.ReadKey(true);

                        if (key.Key == ConsoleKey.UpArrow)
                        {
                            selectedIndex = (selectedIndex == 0) ? question.Options.Count - 1 : selectedIndex - 1;
                        }
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            selectedIndex = (selectedIndex == question.Options.Count - 1) ? 0 : selectedIndex + 1;
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            if (question.IsSingleAnswer)
                            {
                                selectedIndexes.Clear();
                                selectedIndexes.Add(selectedIndex);
                                isAnswered = true;
                            }
                            else
                            {
                                if (!selectedIndexes.Contains(selectedIndex))
                                {
                                    selectedIndexes.Add(selectedIndex);
                                    if (selectedIndexes.Count == question.CorrectIndexes.Count)
                                    {
                                        isAnswered = true;
                                    }
                                }
                                else
                                {
                                    isAnswered = true;
                                }
                            }
                        }
                    }

                    bool allCorrect = question.CorrectIndexes.Count == selectedIndexes.Count && !question.CorrectIndexes.Except(selectedIndexes).Any();

                    if (allCorrect)
                    {
                        score++;
                    }
                }
            
            


        Console.WriteLine($"Quiz completed! Your score: {score}/{questions.Count}");

                Console.ReadKey();

                Result result = new Result
                {
                    UserName = currentUser,
                    Score = score,
                    Category = category,
                    Date = DateTime.Now
                };
                ResultManager.SaveResult(result);

               
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during the quiz: {ex.Message}");
                Logger.Log($"Error during the quiz: {ex.Message}");
            }
        }
    }
}
