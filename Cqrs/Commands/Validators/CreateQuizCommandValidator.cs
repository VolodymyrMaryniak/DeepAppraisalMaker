﻿using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreVueStarter.Cqrs.Commands.Validators
{
    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        private readonly IQuizRepository _quizRepository;
        public CreateQuizCommandValidator(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100)
                .Must((x) => HaveUniqueName(x, _quizRepository)).WithMessage("Question must be unique.");

            RuleFor(x => x.Questions).NotNull()
                .Must(x => HaveUniqueTexts(x)).WithMessage("Question must be unique.");

            RuleForEach(x => x.Questions)
                .SetValidator(new QuestionValidator());
        }

        private static bool HaveUniqueName(string name, IQuizRepository quizRepository)
        {
            var entityQuizList = quizRepository.GetMany();
            foreach (QuizEntity a in entityQuizList)
            {
                if (a.Name == name)
                    return false;
            }

            return true;
        }

        private static bool HaveUniqueTexts(List<CreateQuizCommand.Question> questions)
        {
            var uniqueAnswerOptionsCount = questions.Select(x => x.Text?.Trim()).Distinct().Count();

            return uniqueAnswerOptionsCount == questions.Count;
        }

        private class QuestionValidator : AbstractValidator<CreateQuizCommand.Question>
        {
            public QuestionValidator()
            {
                RuleFor(x => x.Text).NotEmpty().MaximumLength(300);

                RuleFor(x => x.AnswerOptions)
                    .NotEmpty()
                    .Must(HaveUniqueTexts).WithMessage("Answer options must be unique.");

                RuleForEach(x => x.AnswerOptions)
                    .SetValidator(new AnswerOptionValidator());
            }

            private static bool HaveUniqueTexts(List<CreateQuizCommand.AnswerOption> answerOptions)
            {
                var uniqueAnswerOptionsCount = answerOptions.Select(x => x.Text?.Trim()).Distinct().Count();

                return uniqueAnswerOptionsCount == answerOptions.Count;
            }
        }

        private class AnswerOptionValidator : AbstractValidator<CreateQuizCommand.AnswerOption>
        {
            public AnswerOptionValidator()
            {
                RuleFor(x => x.Text).NotEmpty().MaximumLength(100);
            }
        }
    }
}
