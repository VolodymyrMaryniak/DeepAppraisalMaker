using AspNetCoreVueStarter.Data.Configurations;
using AspNetCoreVueStarter.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreVueStarter.Data
{
	public class DamDbContext : DbContext
	{
		public DamDbContext(DbContextOptions<DamDbContext> options)
			: base(options)
		{
		}

		public DbSet<QuizEntity> Quizzes { get; set; }
		public DbSet<QuestionEntity> Questions { get; set; }
		public DbSet<AnswerOptionEntity> AnswerOptions { get; set; }
		public DbSet<StudentEntity> Students { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new QuizEntityConfiguration());
			modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
			modelBuilder.ApplyConfiguration(new AnswerOptionEntityConfiguration());
			modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
		}
	}
}
