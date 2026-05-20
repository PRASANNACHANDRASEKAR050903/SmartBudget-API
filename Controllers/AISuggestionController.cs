using Microsoft.AspNetCore.Mvc;

namespace SmartBudget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AISuggestionController : ControllerBase
    {
        [HttpPost("ask")]
        public IActionResult AskQuestion([FromBody] QuestionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Question))
            {
                return BadRequest(new
                {
                    message = "Please enter your question"
                });
            }

            string question = request.Question.ToLower();
            string response = "";

            if (question.Contains("save money"))
            {
                response = "Track daily expenses, avoid unnecessary spending, and create a monthly budget.";
            }
            else if (question.Contains("budget"))
            {
                response = "Use the 50-30-20 rule: 50% for needs, 30% for wants, and 20% for savings.";
            }
            else if (question.Contains("food"))
            {
                response = "Reduce outside food expenses and plan weekly grocery shopping.";
            }
            else if (question.Contains("travel"))
            {
                response = "Use public transport and avoid unnecessary trips to reduce travel expenses.";
            }
            else if (question.Contains("investment"))
            {
                response = "Start with SIP, Fixed Deposit, or Mutual Funds for safer investments.";
            }
            else if (question.Contains("loan"))
            {
                response = "Avoid unnecessary loans and always maintain an emergency savings fund.";
            }
            else
            {
                response = "Please control your expenses, save regularly, and plan your monthly budget wisely.";
            }

            return Ok(new
            {
                message = response
            });
        }
    }

    public class QuestionRequest
    {
        public string? Question { get; set; }
    }
}