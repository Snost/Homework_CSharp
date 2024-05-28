using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamCSharp
{
    public static class UserInputValidator
    {
        public static bool ValidatePassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        public static bool ValidateQuestion(Question question)
        {
            if (string.IsNullOrWhiteSpace(question.Text))
            {
                Console.WriteLine("Question text cannot be empty.");
                return false;
            }

            if (question.Options == null || !question.Options.Any())
            {
                Console.WriteLine("Question must have at least one option.");
                return false;
            }

            if (question.CorrectIndexes == null || !question.CorrectIndexes.Any())
            {
                Console.WriteLine("Question must have at least one correct answer.");
                return false;
            }

            foreach (var index in question.CorrectIndexes)
            {
                if (index < 0 || index >= question.Options.Count)
                {
                    Console.WriteLine("Correct answer index out of range.");
                    return false;
                }
            }

            return true;
        }
    }
}
