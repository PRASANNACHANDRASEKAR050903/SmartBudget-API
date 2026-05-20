using Microsoft.AspNetCore.Mvc;
using SmartBudget.API.Models;
using SmartBudget.API.Repository;

namespace SmartBudget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseRepository _repository;

        public ExpenseController(ExpenseRepository repository)
        {
            _repository = repository;
        }

        // Add Expense
        [HttpPost("add")]
        public IActionResult AddExpense([FromBody] Expense expense)
        {
            _repository.AddExpense(expense);

            return Ok(new
            {
                message = "Expense added successfully"
            });
        }

        // Get All Expenses
        [HttpGet("list")]
        public IActionResult GetExpenses()
        {
            var data = _repository.GetAllExpenses();

            return Ok(data);
        }

        // Delete Expense
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var result = _repository.DeleteExpense(id);

            if (!result)
                return NotFound("Expense not found");

            return Ok("Deleted successfully");
        }
    }
}