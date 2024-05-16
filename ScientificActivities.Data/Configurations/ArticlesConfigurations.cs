﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificActivities.Data.Models.Publication;

namespace ScientificActivities.Data.Configurations
{
    public class ArticlesConfigurations : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Journal)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.JournalId)
                .IsRequired();
        }
    }
}