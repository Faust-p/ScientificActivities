using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Data.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
    
        builder.HasKey(x => x.Id);
            
        // Настройка связи с Faculty
        builder.HasOne(d => d.Faculty)
            .WithMany(f => f.Departments)
            .IsRequired();

        // Настройка связи с Author
        builder.HasMany(d => d.Authors)
            .WithOne(a => a.Department)
            .IsRequired();
    }
}