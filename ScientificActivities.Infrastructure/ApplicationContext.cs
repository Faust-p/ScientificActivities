using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Data.Models.University;
using ScientificActivities.Data.Models.UserActivity;

namespace ScientificActivities.Infrastructure;

public sealed class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        //Database.Migrate();
    }

    public DbSet<Faculty> Faculties { get; private set; }

    public DbSet<Department> Departments { get; private set; }

    public DbSet<Author> Authors { get; private set; }

    public DbSet<Article> Articles { get; private set; }

    public DbSet<Journal> Journals { get; private set; }

    public DbSet<PublishingHouse> PublishingHouses { get; private set; }

    public DbSet<User> Users { get; private set; }

    public DbSet<MailToken> MailToken { get; private set; }
    
    public DbSet<ArticlesAuthors> ArticlesAuthors { get; private set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ScientificActivities;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        mb.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}

