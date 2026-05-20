using Microsoft.AspNetCore.Mvc;
using SmartBudget.API.Models;
using SmartBudget.API.Repository;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
{
    private readonly BudgetRepository _repository;

    public BudgetController(BudgetRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("add")]
    public IActionResult AddBudget(Budget budget)
    {
        _repository.AddBudget(budget);
        return Ok("Budget added successfully");
    }

    [HttpGet("list")]
    public IActionResult GetBudgets()
    {
        var data = _repository.GetAllBudgets();
        return Ok(data);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteBudget(int id)
    {
        var result = _repository.DeleteBudget(id);

        if (!result)
            return NotFound("Budget not found");

        return Ok("Deleted successfully");
    }
}