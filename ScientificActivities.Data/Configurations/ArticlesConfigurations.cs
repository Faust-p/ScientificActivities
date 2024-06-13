using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models.Publication;

namespace ScientificActivities.Data.Configurations
{
    public class ArticlesConfigurations : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            
            // Настройка связи с Journal
            builder.HasOne(a => a.Journal)
                .WithMany(j => j.Articles)
                .IsRequired();

            // Настройка связи с ArticlesAuthors
            builder.HasMany(a => a.Authors)
                .WithOne(aa => aa.Article)
                .IsRequired();
        }
    }
}