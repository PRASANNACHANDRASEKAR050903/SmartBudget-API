namespace SmartBudget.API.Models;
public class Expense
{
    public int ExpenseId { get; set; }
    public int UserId { get; set; }
    public string? Category { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTime ExpenseDate { get; set; }
}