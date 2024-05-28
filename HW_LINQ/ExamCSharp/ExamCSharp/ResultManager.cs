using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExamCSharp
{
    public static class ResultManager
    {
        private static readonly string resultsFilePath = "results.json";

        public static void SaveResult(Result result)
        {
            try
            {
                List<Result> results = LoadResults();
                results.Add(result);
                File.WriteAllText(resultsFilePath, JsonConvert.SerializeObject(results, Formatting.Indented));
                Logger.Log("Result saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving result: {ex.Message}");
                Logger.Log($"Error saving result: {ex.Message}");
            }
        }

        public static List<Result> LoadResults()
        {
            try
            {
                if (!File.Exists(resultsFilePath))
                {
                    return new List<Result>();
                }

                string json = File.ReadAllText(resultsFilePath);
                return JsonConvert.DeserializeObject<List<Result>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading results: {ex.Message}");
                Logger.Log($"Error loading results: {ex.Message}");
                return new List<Result>();
            }
        }

        public static void Show(string currentUser)
        {
            try
            {
                string[] choiceResult = { "Show Top 20", "Results of past quizzes", "Exit" };
                int selectedIndex = 0;

                while (true)
                {
                    Console.Clear();
                    MenuPrinter.PrintCenteredMenu(choiceResult, selectedIndex);

                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = (selectedIndex == 0) ? choiceResult.Length - 1 : selectedIndex - 1;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex == choiceResult.Length - 1) ? 0 : selectedIndex + 1;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (choiceResult[selectedIndex] == "Show Top 20")
                        {
                            ShowResultsTop20();
                        }
                        else if (choiceResult[selectedIndex] == "Results of past quizzes")
                        {
                            ShowResults(currentUser);
                        }
                        else if (choiceResult[selectedIndex] == "Exit")
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error showing results: {ex.Message}");
                Logger.Log($"Error showing results: {ex.Message}");
            }
        }

        public static List<Result> GetTop20Results()
        {
            try
            {
                List<Result> results = LoadResults();
                return results.OrderByDescending(r => r.Score)
                              .ThenBy(r => r.Date)
                              .GroupBy(r => r.UserName)
                              .Select(g => g.OrderByDescending(r => r.Score).First())
                              .OrderByDescending(r => r.Score)
                              .ThenBy(r => r.Date)
                              .Take(20)
                              .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting top 20 results: {ex.Message}");
                Logger.Log($"Error getting top 20 results: {ex.Message}");
                return new List<Result>();
            }
        }

        public static List<Result> GetResults(string userName)
        {
            try
            {
                List<Result> results = LoadResults();
                return results.Where(r => r.UserName == userName)
                              .OrderByDescending(r => r.Score)
                              .ThenBy(r => r.Date)
                              .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting results for user {userName}: {ex.Message}");
                Logger.Log($"Error getting results for user {userName}: {ex.Message}");
                return new List<Result>();
            }
        }

        private static void ShowResultsTop20()
        {
            try
            {
                Console.Clear();
                var results = ResultManager.GetTop20Results();

                Console.WriteLine("Top 20 Results:\nUser name\tScore\tCategory\tDate");

                foreach (var result in results)
                {
                    Console.WriteLine($"{result.UserName} \t\t {result.Score}/20 \t {result.Category} \t {result.Date}");
                }

                Console.ReadKey();
                Logger.Log("Top 20 results viewed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error showing top 20 results: {ex.Message}");
                Logger.Log($"Error showing top 20 results: {ex.Message}");
            }
        }

        private static void ShowResults(string currentUser)
        {
            try
            {
                Console.Clear();
                var results = ResultManager.GetResults(currentUser);
                Console.WriteLine("Your Results:");
                Console.WriteLine("Score\tCategory\tDate");
                foreach (var result in results)
                {
                    Console.WriteLine($"{result.Score}/20 \t {result.Category} \t {result.Date}");
                }

                Console.ReadKey();
                Logger.Log("User results viewed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error showing user results: {ex.Message}");
                Logger.Log($"Error showing user results: {ex.Message}");
            }
        }
    }


    [Serializable]
    public class Result
    {
        public string UserName { get; set; }
        public int Score { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
