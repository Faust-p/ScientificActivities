using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models;

namespace ScientificActivities.Data.Configurations;

public class CuAuthorConfigurations :
    IEntityTypeConfiguration<СoАuthor>
{
    public void Configure(EntityTypeBuilder<СoАuthor> builder)
    {
        builder.HasKey(x => x.Id);
    }
}