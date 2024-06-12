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
            
            /*
            builder.HasOne(x => x.Journal)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.JournalId)
                .IsRequired();
            */
                /*
            builder.HasOne(a => a.Journal) // Отношение один к одному с журналом
                .WithMany(x=> x.Articles)
                .HasForeignKey("JournalId");

            builder.HasMany(a => a.Authors) // Отношение один ко многим с авторами
                .WithOne()
                .HasForeignKey("ArticleId"); */
        }
    }
}