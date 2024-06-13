using ScientificActivities.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Data.Configurations;

public class AuthorConfigurations :
    IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(a => a.Department)
            .WithMany(d => d.Authors);
        
        builder.HasMany(a => a.Articles)
            .WithOne(aa => aa.Author);
    }
}