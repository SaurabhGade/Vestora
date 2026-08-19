using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Entities;

namespace Vestora.DAL.Data;

public class VestoraDbContext : DbContext
{
    public VestoraDbContext(DbContextOptions<VestoraDbContext> options): base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<ConfigSetting> ConfigSettings { get; set; }
    public DbSet<Security> Securities {get; set;}

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(VestoraDbContext).Assembly);
    }
}