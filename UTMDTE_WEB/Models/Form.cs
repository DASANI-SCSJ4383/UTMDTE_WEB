using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UTMDTE_WEB.Models
{
    public class Form
    {
        public int? ID { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(255)]
        public string? Description { get; set; }

        public int? UtmleadAdministratorID { get; set; }

        [BindProperty]
        public List<Rubric>? Rubric { get; set; }
    }
}
