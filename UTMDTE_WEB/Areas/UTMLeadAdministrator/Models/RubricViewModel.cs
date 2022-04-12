using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UTMDTE_WEB.Models;

namespace UTMDTE_WEB.Areas.UTMLeadAdministrator.Models
{
    public class RubricViewModel
    {
        public Rubric? Rubric { get; set; }

        public List<Rubric>? Rubrics { get; set; }

        public Form Form { get; set; }

        public RubricViewModel(Rubric? rubric, List<Rubric>? rubrics, Form form)
        {
            Rubric = rubric;
            Rubrics = rubrics;
            Form = form;
        }

        public RubricViewModel()
        {

        }
    }

    
}
