using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models.Tables;

namespace ScientificActivities.Data.Configurations
{
    public class JournalConfigurations : IEntityTypeConfiguration<Journal>
    {
        public void Configure(EntityTypeBuilder<Journal> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.PublishingHouse)
                .WithMany(x => x.Journals)
                .HasForeignKey(x => x.PublishingHouseId)
                .IsRequired();
        }
    }
}