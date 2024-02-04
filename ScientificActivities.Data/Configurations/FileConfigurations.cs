using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = ScientificActivities.Data.Models.File;

namespace ScientificActivities.Data.Configurations;

public class FileConfigurations : 
    IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.Files)
            .HasForeignKey(x => x.AuthorId);
    }
}