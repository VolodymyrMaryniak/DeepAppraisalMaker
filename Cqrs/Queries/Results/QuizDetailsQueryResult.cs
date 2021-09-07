using System;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Cqrs.Queries.Results
{
    public class QuizDetailsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

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
