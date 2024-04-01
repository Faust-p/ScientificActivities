using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.Tables;
using File = ScientificActivities.Data.Models.File;

namespace ScientificActivities.Data;

public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        //Database.Migrate();
    }

    public DbSet<Faculty> Faculties { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Articles> Articles { get; set; }

    public DbSet<СoАuthor> СoАuthors { get; set; }

    public DbSet<File> Files { get; set; }

    public DbSet<Journal> Journals { get; set; }

    public DbSet<PublishingHouse> PublishingHouses { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<MailToken> MailToken { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        mb.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}