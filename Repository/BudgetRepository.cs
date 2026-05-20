using SmartBudget.API.Data;
using SmartBudget.API.Models;

namespace SmartBudget.API.Repository
{
    public class BudgetRepository
    {
        private readonly AppDbContext _context;

        public BudgetRepository(AppDbContext context)
        {
            _context = context;
        }

        // Add Budget
        public void AddBudget(Budget budget)
        {
            _context.Budgets.Add(budget);
            _context.SaveChanges();
        }

        // Get All Budgets
        public List<Budget> GetAllBudgets()
        {
            return _context.Budgets.ToList();
        }

        // Get Budget By Id
        public Budget? GetBudgetById(int id)
        {
            return _context.Budgets.Find(id);
        }

        // Delete Budget
        public bool DeleteBudget(int id)
        {
            var budget = _context.Budgets.Find(id);

            if (budget == null)
                return false;

            _context.Budgets.Remove(budget);
            _context.SaveChanges();
            return true;
        }
    }
}