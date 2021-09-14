using AspNetCoreVueStarter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreVueStarter.Data.Configurations
{
    public class StudentAnswerEntityConfiguration : IEntityTypeConfiguration<StudentAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<StudentAnswerEntity> builder)
        {
            builder.ToTable("StudentAnswer");

            builder.Property(x => x.Id).IsRequired();

            builder.HasOne(x => x.QuizPassing)
                .WithMany(x => x.StudentAnswers)
                .HasForeignKey(x => x.QuizPassingId);

            builder.HasOne(x => x.Question);
            builder.HasOne(x => x.ChosenAnswerOption);
        }
    }
}