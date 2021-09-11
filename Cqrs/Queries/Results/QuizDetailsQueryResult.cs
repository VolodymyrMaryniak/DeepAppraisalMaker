using AspNetCoreVueStarter.Models;
using System;

namespace AspNetCoreVueStarter.Cqrs.Queries.Results
{
    public class QuizDetailsQueryResult : Quiz
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
