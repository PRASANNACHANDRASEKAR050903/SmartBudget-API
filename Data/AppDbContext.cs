using Microsoft.EntityFrameworkCore;
using SmartBudget.API.Models;

namespace SmartBudget.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<AISuggestion> AISuggestions { get; set; }
    }
}