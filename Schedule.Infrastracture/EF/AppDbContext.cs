using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Schedule.Core.Models;

namespace Schedule.Infrastracture.EF;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Group> Groups { get; set; }
}
