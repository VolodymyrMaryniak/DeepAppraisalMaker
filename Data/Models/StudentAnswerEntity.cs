namespace AspNetCoreVueStarter.Data.Models
{
    public class StudentAnswerEntity
    {
        public int Id { get; set; }

        public int? QuizPassingId { get; set; }
        public QuizPassingEntity QuizPassing { get; set; }

        public int? QuestionId { get; set; }
        public QuestionEntity Question { get; set; }

        public int? ChosenAnswerId { get; set; }
        public AnswerOptionEntity ChosenAnswerOption { get; set; }
    }
}
