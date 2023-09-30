using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LoveLiveCZ.Models.Database;

public class LoveLiveCzDatabaseContext : DbContext
{
    private const string SchemaName = "love_live_cz";

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public LoveLiveCzDatabaseContext(DbContextOptions<LoveLiveCzDatabaseContext> options)
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

        modelBuilder.Entity<Like>().HasNoKey();
        
        modelBuilder.Entity<UserRole>().HasNoKey();
        modelBuilder.Entity<UserRole>().HasIndex(x => new { x.UserId, x.Role }).IsUnique();
    }
}