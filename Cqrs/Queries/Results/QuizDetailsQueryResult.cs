using System;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Cqrs.Queries.Results
{
    public class QuizDetailsQueryResult
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime QuizCreatedAt { get; set; }
        public DateTime QuizModifiedAt { get; set; }

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
