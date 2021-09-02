using AspNetCoreVueStarter.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Services.Interfaces
{
    public interface IQuizService
    {
        Task<List<QuizSummaryViewModel>> GetQuizSummaryViewModelsAsync();
        Task<EditQuizViewModel> GetQuizDetailsAsync(int quizId);
    }
}
