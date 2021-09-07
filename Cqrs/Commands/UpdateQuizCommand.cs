using AspNetCoreVueStarter.Cqrs.Commands.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Cqrs.Commands
{
    public class UpdateQuizCommand : IRequest<UpdateQuizCommandResult>
    {
        [FromRoute]
        public int Id { get; set; }
        public string QuizName { get; set; }
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
