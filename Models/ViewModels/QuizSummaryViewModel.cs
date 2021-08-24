using System;

namespace AspNetCoreVueStarter.Models.ViewModels
{
	public class QuizSummaryViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
