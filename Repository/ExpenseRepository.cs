using SmartBudget.API.Data;
using SmartBudget.API.Models;

namespace SmartBudget.API.Repository
{
    public class ExpenseRepository
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        // Add Expense
        public void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        // Get All Expenses
        public List<Expense> GetAllExpenses()
        {
            return _context.Expenses
                           .OrderByDescending(e => e.ExpenseDate)
                           .ToList();
        }

        // Delete Expense
        public bool DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);

            if (expense == null)
                return false;

            _context.Expenses.Remove(expense);

            _context.SaveChanges();

            return true;
        }
    }
}