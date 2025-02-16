using GoalTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using static GoalTrackerAPI.Models.Goals;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Goals> Goals { get; set; }  // Tabla para las metas
    public DbSet<User> Users { get; set; }  // Tabla para los usuarios
}
