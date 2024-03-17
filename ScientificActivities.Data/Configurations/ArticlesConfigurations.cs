using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models.Tables;

namespace ScientificActivities.Data.Configurations
{
    public class ArticlesConfigurations : IEntityTypeConfiguration<Articles>
    {
        public void Configure(EntityTypeBuilder<Articles> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Journal)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.JournalId)
                .IsRequired();
        }
    }
}