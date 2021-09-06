using AspNetCoreVueStarter.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreVueStarter.Models;
using AspNetCoreVueStarter.Models.Shared;

namespace AspNetCoreVueStarter.Services.Interfaces
{
    public interface IQuizService
    {
        Task<List<QuizSummaryViewModel>> GetQuizSummaryViewModelsAsync();
        Task<EditQuizViewModel> GetQuizDetailsAsync(int quizId);
        Task<OperationResult> CreateQuizAsync(Quiz quiz);
        Task<OperationResult> UpdateQuizAsync(int quizId, Quiz quiz);
    }
}
