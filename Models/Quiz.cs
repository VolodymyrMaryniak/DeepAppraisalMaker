using System.Collections.Generic;

namespace AspNetCoreVueStarter.Models
{
    public class Quiz
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public class Question
        {
            public string Text { get; set; }
            public List<AnswerOption> AnswerOptions { get; set; }
        }

        public class AnswerOption
        {
            public string Text { get; set; }
            public bool IsCorrectAnswer { get; set; }
        }
    }
}
