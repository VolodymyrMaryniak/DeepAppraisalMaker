using System;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Data.Models
{
    public class QuizPassingEntity
    {
        public int Id { get; set; }
        public DateTime PassingDate { get; set; }

        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }

        public int QuizId { get; set; }
        public QuizEntity Quiz { get; set; }

        public List<StudentAnswerEntity> StudentAnswers { get; set; }
    }
}
