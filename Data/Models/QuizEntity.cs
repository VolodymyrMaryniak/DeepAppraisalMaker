using System;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Data.Models
{
	public class QuizEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }

		public List<QuestionEntity> Questions { get; set; } 
	}
}
