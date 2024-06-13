using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models.Publication;

namespace ScientificActivities.Data.Configurations
{
    public class JournalConfigurations : IEntityTypeConfiguration<Journal>
    {
        public void Configure(EntityTypeBuilder<Journal> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(j => j.PublishingHouse)
                .WithMany(ph => ph.Journals)
                .IsRequired();
            
            builder.HasMany(j => j.Articles)
                .WithOne(a => a.Journal)
                .IsRequired();
        }
    }
}