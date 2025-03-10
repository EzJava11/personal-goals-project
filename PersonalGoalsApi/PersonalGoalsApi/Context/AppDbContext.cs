using Microsoft.EntityFrameworkCore;
using PersonalGoalsApi.Models;

namespace PersonalGoalsApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Goal> Goals { get; set; }
    }
}
