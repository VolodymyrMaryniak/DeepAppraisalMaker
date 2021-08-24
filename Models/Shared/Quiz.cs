using System;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Models.Shared
{
	public class Quiz
	{
		public string Name { get; set; }
		public List<Question> Questions { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
