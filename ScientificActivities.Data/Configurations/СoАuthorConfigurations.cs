using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Data.Configurations;

public class CuAuthorConfigurations :
    IEntityTypeConfiguration<CoAuthor>
{
    public void Configure(EntityTypeBuilder<CoAuthor> builder)
    {
        builder.HasKey(x => x.Id);
    }
}