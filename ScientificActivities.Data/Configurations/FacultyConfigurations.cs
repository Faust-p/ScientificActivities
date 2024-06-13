using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Data.Configurations;

public class FacultyConfigurations :
    IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasKey(x => x.Id);
        
        // Настройка связи с Department
        builder.HasMany(f => f.Departments)
            .WithOne(d => d.Faculty)
            .IsRequired();
    }
}