using JWT.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT.Context;

public class DatabaseContext : DbContext
{
    public DbSet<AppUserModel> AppUserModels { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}