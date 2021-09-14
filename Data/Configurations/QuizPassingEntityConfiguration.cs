using AspNetCoreVueStarter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreVueStarter.Data.Configurations
{
    public class QuizPassingEntityConfiguration : IEntityTypeConfiguration<QuizPassingEntity>
    {
        public void Configure(EntityTypeBuilder<QuizPassingEntity> builder)
        {
            builder.ToTable("QuizPassing");

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.PassingDate).IsRequired();

            builder.HasOne(x => x.Quiz);

            builder.HasOne(x => x.Student);

            builder.HasMany(x => x.StudentAnswers);
        }
    }
}
