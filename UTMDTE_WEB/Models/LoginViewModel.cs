using System.ComponentModel.DataAnnotations;

namespace UTMDTE_WEB.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter UTM ID")]
        [Display(Name = "UTM ID")]
        public string? UTMID { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
