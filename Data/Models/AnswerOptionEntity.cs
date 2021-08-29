namespace AspNetCoreVueStarter.Data.Models
{
	public class AnswerOptionEntity
	{
		public int Id { get; set; }
		public string AnswerOptionText { get; set; }
		public bool IsCorrectAnswer { get; set; }

		public int QuestionId { get; set; }
		public QuestionEntity Question { get; set; }
	}
}
