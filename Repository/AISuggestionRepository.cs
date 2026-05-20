using SmartBudget.API.Data;
using SmartBudget.API.Models;

namespace SmartBudget.API.Repository
{
    public class AISuggestionRepository
    {
        private readonly AppDbContext _context;

        public AISuggestionRepository(AppDbContext context)
        {
            _context = context;
        }

        // Generate AI Suggestion based on user question
        public string GenerateSuggestion(string question)
        {
            string suggestion = "";

            question = question.ToLower();

            if (question.Contains("save money"))
            {
                suggestion = "Track daily expenses, avoid unnecessary spending, and create a monthly budget.";
            }
            else if (question.Contains("budget"))
            {
                suggestion = "Use the 50-30-20 budgeting rule: 50% for needs, 30% for wants, and 20% for savings.";
            }
            else if (question.Contains("investment"))
            {
                suggestion = "Start with low-risk investments like SIP, Fixed Deposit, or Mutual Funds.";
            }
            else if (question.Contains("food"))
            {
                suggestion = "Reduce outside food expenses and plan weekly grocery shopping to save money.";
            }
            else if (question.Contains("travel"))
            {
                suggestion = "Use public transport and avoid unnecessary trips to reduce travel expenses.";
            }
            else
            {
                suggestion = "Control unnecessary expenses, save regularly, and follow your monthly budget plan.";
            }

            // Save suggestion into database
            var aiSuggestion = new AISuggestion
            {
                SuggestionText = suggestion,
                GeneratedDate = DateTime.Now
            };

            _context.AISuggestions.Add(aiSuggestion);
            _context.SaveChanges();

            return suggestion;
        }

        // Get all saved suggestions
        public List<AISuggestion> GetSuggestions()
        {
            return _context.AISuggestions.ToList();
        }

        // Delete suggestion
        public bool DeleteSuggestion(int id)
        {
            var suggestion = _context.AISuggestions.Find(id);

            if (suggestion == null)
                return false;

            _context.AISuggestions.Remove(suggestion);
            _context.SaveChanges();

            return true;
        }
    }
}