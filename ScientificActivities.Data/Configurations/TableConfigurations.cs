using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models;

namespace ScientificActivities.Data.Configurations;

public class TableConfigurations :
    IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(x => x.Id);
    }
}