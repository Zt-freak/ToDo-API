using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
