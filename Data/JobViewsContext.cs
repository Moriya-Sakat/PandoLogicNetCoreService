using Microsoft.EntityFrameworkCore;
using PandoLogic.Models;

namespace PandoLogic.Data;

public class JobViewsContext : DbContext
{
    public JobViewsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<View> Views => Set<View>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Job).Assembly);
    }
}