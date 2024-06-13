using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models.Publication;

namespace ScientificActivities.Data.Configurations
{
    public class PublishingHouseConfigurations : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.HasKey(x => x.Id);
            
            // Настройка связи с Journal
            builder.HasMany(ph => ph.Journals)
                .WithOne(j => j.PublishingHouse)
                .IsRequired();
        }
    }
}