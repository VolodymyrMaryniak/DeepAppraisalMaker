using System.Collections.Generic;

namespace AspNetCoreVueStarter.Models.Shared
{
	public class Question
	{
		public string Text { get; set; }
		public List<AnswerOption> AnswerOptions { get; set; }
	}
}
