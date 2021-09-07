﻿using System;

namespace AspNetCoreVueStarter.Cqrs.Queries.Results
{
    public class QuizSummariesQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
