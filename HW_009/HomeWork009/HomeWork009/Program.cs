namespace HomeWork009;
using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    static void Main(string[] args)
    {
        bool isStart = true;

        while (isStart)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║        English-French dictionary         ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║1. Add word and translation options       ║");
            Console.WriteLine("║2. Delete the word                        ║");
            Console.WriteLine("║3. Delete translation options             ║");
            Console.WriteLine("║4. Change the word                        ║");
            Console.WriteLine("║5. Change translation option              ║");
            Console.WriteLine("║6. Search for the translation of the word ║");
            Console.WriteLine("║7. Exit                                   ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");

            Console.Write("Select an option:");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    AddWord();
                    break;
                case "2":
                    RemoveWord();
                    break;
                case "3":
                    RemoveTranslation();
                    break;
                case "4":
                    ModifyWord();
                    break;
                case "5":
                    ChangeTranslation();
                    break;
                case "6":
                    SearchTranslation();
                    break;
                case "7":
                    isStart = false;
                    break;
                default:
                    Console.WriteLine("Error!Select an option 1-7! ");
                    break;
            }
        }
    }

    static void AddWord()
    {
        Console.Write("Enter the word in English: ");
        string word = Console.ReadLine();

        if (!dictionary.ContainsKey(word))
        {
            Console.Write("Enter French translation options (through comma):");
            string translInput = Console.ReadLine();
            string[] transl = translInput.Split(',');

            List<string> translList = new List<string>();
            foreach (var translation in transl)
            {
                translList.Add(translation.Trim());
            }

            dictionary.Add(word, translList);

            Console.WriteLine($"The word '{word}' and its transl have been added to the dictionary.");
        }
        else
        {
            Console.WriteLine($"The word '{word}' already exists in the dictionary.");
        }
    }

    static void RemoveWord()
    {
        Console.Write("Enter the word in English that you want to delete: ");
        string word = Console.ReadLine();

        if (dictionary.ContainsKey(word))
        {
            dictionary.Remove(word);
            Console.WriteLine($"The word '{word}' has been removed");
}
        else
        {
            Console.WriteLine($"The word '{word}' was not found in the dictionary.");
        }
    }

    static void RemoveTranslation()
    {
        Console.Write("Enter the English word for which you want to remove the translation:");
        string word = Console.ReadLine();

        if (dictionary.ContainsKey(word))
        {
            Console.Write($"Enter the French translation option that you want to remove (enter with comma):");
            string translRemove = Console.ReadLine();

            if (dictionary[word].Contains(translRemove))
            {
                dictionary[word].Remove(translRemove);
                Console.WriteLine($"The translation option '{translRemove}' has been removed for the word '{word}'.");
            }
            else
            {
                Console.WriteLine($"Translation '{translRemove}' not found for word '{word}'.");
            }
        }
        else
        {
            Console.WriteLine($"The word '{word}' was not found in the dictionary.");
        }
    }

    static void ModifyWord()
    {
        Console.Write("Enter the English word to change:");
        string oldWord = Console.ReadLine();

        if (dictionary.ContainsKey(oldWord))
        {
            Console.Write("Enter a new word in English: ");
            string newWord = Console.ReadLine();

            dictionary.Add(newWord, dictionary[oldWord]);
            dictionary.Remove(oldWord);

            Console.WriteLine($"The word '{oldWord}' has been changed to '{newWord}'.");
        }
        else
        {
            Console.WriteLine($"The word '{oldWord}' was not found in the dictionary.");
        }
    }

    static void ChangeTranslation()
    {
        Console.Write("Enter the English word for which you want to change the translation:");
        string word = Console.ReadLine();

        if (dictionary.ContainsKey(word))
        {
            Console.Write("Enter the current version of the French translation:");
            string oldTranslation = Console.ReadLine();

            if (dictionary[word].Contains(oldTranslation))
            {
                Console.Write("Enter a new translation option in French: ");
                string newTranslation = Console.ReadLine();

                int index = dictionary[word].IndexOf(oldTranslation);
                dictionary[word][index] = newTranslation;

                Console.WriteLine($"The translation '{oldTranslation}' has been changed to '{newTranslation}' for the word '{word}'.");
            }
            else
            {
                Console.WriteLine($"Translation '{oldTranslation}' not found for word '{word}'.");
            }
        }
        else
        {
            Console.WriteLine($"The word '{word}' was not found in the dictionary.");
        }
    }

    static void SearchTranslation()
    {
        Console.Write("Enter a word in English to find translation: ");
        string word = Console.ReadLine();

        if (dictionary.ContainsKey(word))
        {
            Console.WriteLine($"Translation for the word '{word}':");
            foreach (string translation in dictionary[word])
            {
                Console.WriteLine(translation);
            }
        }
        else
        {
            Console.WriteLine($"The word '{word}' was not found in the dictionary.");
        }
    }
}
