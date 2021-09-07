using System;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Cqrs.Queries.Results
{
    public class QuizSummariesQueryResult : List<QuizSummariesQueryResult.QuizSummary>
    {
        public class QuizSummary
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime ModifiedAt { get; set; }
        }
    }
}
