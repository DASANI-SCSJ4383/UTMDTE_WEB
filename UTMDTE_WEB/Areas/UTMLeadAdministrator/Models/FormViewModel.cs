using UTMDTE_WEB.Models;

namespace UTMDTE_WEB.Areas.UTMLeadAdministrator.Models
{
    public class FormViewModel
    {
        public Form? Form { get; set; }

        public List<Form>? Forms { get; set; }

        public FormViewModel(Form? form, List<Form>? forms)
        {
            Form = form;
            Forms = forms;
        }

        public FormViewModel()
        {
        }
    }
}
