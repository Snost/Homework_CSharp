using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExamCSharp
{
    [Serializable]
    public class Quiz
    {
        public string Category { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

        public Quiz() { }

        public Quiz(string category)
        {
            Category = category;
        }
    }


    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public List<int> CorrectIndexes { get; set; }
        public string Category { get; set; }
        public bool IsSingleAnswer { get; set; } 
    }


}
