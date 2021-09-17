using AspNetCoreVueStarter.Data;
using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Services
{
    public class QuizService
    {
        private readonly IMapper _mapper;
        private readonly IQuizRepository _quizRepository;
        private readonly DamDbContext _quizPassingContext;

        public QuizService(IMapper mapper, IQuizRepository quizRepository, DamDbContext quizPassingContext)
        {
            _mapper = mapper;
            _quizRepository = quizRepository;
            _quizPassingContext = quizPassingContext;
        }

        public async Task<QuizEntity> CreateQuiz(QuizEntity quizEntity)
        {
            quizEntity.IsActive = false;

            var activeQuizEntity = CopyQuiz(quizEntity);

            activeQuizEntity.IsActive = true;
            activeQuizEntity.ModifiedDate = DateTime.Now;

            await _quizRepository.AddAsync(activeQuizEntity);

            return activeQuizEntity;
        }

        public QuizEntity CopyQuiz(QuizEntity quizEntity)
        {
            var quiz = _mapper.Map<Quiz>(quizEntity);

            return _mapper.Map<QuizEntity>(quiz);
        }

        public async Task<bool> QuizUsed(int id, CancellationToken cancellationToken)
        {
            return await _quizPassingContext.Set<QuizPassingEntity>().AnyAsync(x => x.QuizId == id, cancellationToken);
        }

        public async Task<QuizEntity> GetById(int id, CancellationToken cancellationToken)
        {
            return await _quizRepository.GetMany().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
