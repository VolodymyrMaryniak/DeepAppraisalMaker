using AspNetCoreVueStarter.Models.ViewModels;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Cqrs.Queries.Results
{
    public class QuizSummariesQueryResult : List<QuizSummaryViewModel>
    {
        public QuizSummariesQueryResult(IEnumerable<QuizSummaryViewModel> collection) : base(collection)
        {
        }
    }
}
