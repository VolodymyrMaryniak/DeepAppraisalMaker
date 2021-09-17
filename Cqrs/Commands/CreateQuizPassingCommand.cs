using AspNetCoreVueStarter.Cqrs.Commands.Results;
using MediatR;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Cqrs.Commands
{
    public class CreateQuizPassingCommand : IRequest<CreateQuizPassingCommandResult>
    {
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public List<StudentAnswer> StudentAnswers { get; set; }
        public class StudentAnswer
        {
            public int QuestionId { get; set; }
            public int AnswerOptionId { get; set; }
        }
    }
}
