using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models;

namespace ScientificActivities.Data.Configurations;

public class UserConfigurations :
    IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasMany(x => x.Tokens)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}