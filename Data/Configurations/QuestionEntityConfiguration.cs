using AspNetCoreVueStarter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreVueStarter.Data.Configurations
{
	public class QuestionEntityConfiguration : IEntityTypeConfiguration<QuestionEntity>
	{
		public void Configure(EntityTypeBuilder<QuestionEntity> builder)
		{
			builder.ToTable("Question");

			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.QuestionText).HasMaxLength(300).IsRequired();
			builder.Property(x => x.QuizId).IsRequired();


			builder.HasOne(x => x.Quiz)
				.WithMany(x => x.Questions)
				.HasForeignKey(x => x.QuizId);

			builder.HasMany(x => x.AnswerOptions)
				.WithOne(x => x.Question);
		}
	}
}
