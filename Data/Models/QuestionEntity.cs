using System.Collections.Generic;

namespace AspNetCoreVueStarter.Data.Models
{
	public class QuestionEntity
	{
		public int Id { get; set; }
		public string QuestionText { get; set; }

		public int QuizId { get; set; }
		public QuizEntity Quiz { get; set; }

		public List<AnswerOptionEntity> AnswerOptions { get; set; }
	}
}
