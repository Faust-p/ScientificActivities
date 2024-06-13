using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models.Publication;

namespace ScientificActivities.Data.Configurations;

public class ArticlesAuthorsConfiguration : IEntityTypeConfiguration<ArticlesAuthors>
{
    public void Configure(EntityTypeBuilder<ArticlesAuthors> builder)
    {
        builder.HasOne(e => e.Article) // Отношение один ко многим с Article
            .WithMany(a => a.Authors); 

        builder.HasOne(e => e.Author) // Отношение один ко многим с Author
            .WithMany(a => a.Articles); 
    }
}