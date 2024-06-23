using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.UserActivity;

namespace ScientificActivities.Data.Configurations;

public class MailTokenConfiguration : 
    IEntityTypeConfiguration<MailToken>
{
    public void Configure(EntityTypeBuilder<MailToken> builder)
    {
        builder.HasKey(x => x.Id);
    }
}