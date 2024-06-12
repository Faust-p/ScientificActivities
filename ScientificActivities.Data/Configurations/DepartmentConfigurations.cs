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
            /*
        builder
            .HasOne(x => x.Faculty)
            .WithMany(x => x.Departments);*/
            
        // Настройка связи с Faculty
        builder.HasOne(d => d.Faculty)
            .WithMany(f => f.Departments)
            .IsRequired();

        // Настройка связи с Author
        builder.HasMany(d => d.Authors)
            .WithOne(a => a.Department)
            .IsRequired();
        /*
        entityTypeBuilder.HasKey(x => x.Id);
        entityTypeBuilder
            .HasOne(x => x.Faculty)
            .WithMany(x => x.Departments)
            .HasForeignKey(x => x.FacultyId);
        
        // Настройка отношения "один к одному" между Department и Faculty
        entityTypeBuilder.HasOne(d => d.Faculty) // У каждой кафедры есть один факультет
            .WithMany(f => f.Departments) // У факультета может быть много кафедр
            .HasForeignKey("FacultyId"); // Внешний ключ в таблице Department, ссылающийся на таблицу Faculty

        // Настройка отношения "один ко многим" между Department и Author
        entityTypeBuilder.HasMany(d => d.Authors) // У кафедры может быть много авторов
            .WithOne(a => a.Department) // У автора есть одна кафедра
            .HasForeignKey(a => a.DepartmentId); // Внешний ключ в таблице Author, ссылающийся на таблицу Department */
    }
}