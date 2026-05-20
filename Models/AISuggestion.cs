using System;
using System.ComponentModel.DataAnnotations;

namespace SmartBudget.API.Models
{
    public class AISuggestion
    {
        [Key]
        public int SuggestionId { get; set; }

        public string? SuggestionText { get; set; }

        public DateTime GeneratedDate { get; set; } = DateTime.Now;
    }
}