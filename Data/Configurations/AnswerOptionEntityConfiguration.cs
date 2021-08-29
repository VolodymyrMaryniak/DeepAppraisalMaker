using AspNetCoreVueStarter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreVueStarter.Data.Configurations
{
	public class AnswerOptionEntityConfiguration : IEntityTypeConfiguration<AnswerOptionEntity>
	{
		public void Configure(EntityTypeBuilder<AnswerOptionEntity> builder)
		{
			builder.ToTable("AnswerOption");

			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.AnswerOptionText).HasMaxLength(100).IsRequired();
			builder.Property(x => x.IsCorrectAnswer).IsRequired();
			builder.Property(x => x.QuestionId).IsRequired();

			builder.HasOne(x => x.Question)
				.WithMany(x => x.AnswerOptions)
				.HasForeignKey(x => x.QuestionId);
		}
	}
}
