using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UTMDTE_WEB.Models
{
    public class Rubric
    {
        public int? ID { get; set; }

        [BindProperty, Required]
        public string? RubricType { get; set; } = "Radio Button";
        public string[] RubricTypes { get; } = new[] { "Radio Button", "Checkbox", "Dropdown", "Textbox" };

        [Required]
        public string? Description { get; set; }

        [Display(Name = "Answer(s)")]
        public string[]? Answers { get; set; }

        public int? FormID { get; set; }
    }
}
