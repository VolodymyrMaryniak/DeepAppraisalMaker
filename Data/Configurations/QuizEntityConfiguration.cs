using AspNetCoreVueStarter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreVueStarter.Data.Configurations
{
    public class QuizEntityConfiguration : IEntityTypeConfiguration<QuizEntity>
    {
        public void Configure(EntityTypeBuilder<QuizEntity> builder)
        {
            builder.ToTable("Quiz");

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Quiz);
        }
    }
}
