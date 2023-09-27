using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LoveLiveCZ.Models.Database;

public class LoveLiveCZDatabaseContext : DbContext
{
    private const string SchemaName = "love_live_cz";

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Attachment> Attachments { get; set; }

    public LoveLiveCZDatabaseContext(DbContextOptions<LoveLiveCZDatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);
        modelBuilder.SetDefaultValues();

        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();
        modelBuilder.Entity<User>().Property(x => x.DisplayName).IsRequired();
    }
}