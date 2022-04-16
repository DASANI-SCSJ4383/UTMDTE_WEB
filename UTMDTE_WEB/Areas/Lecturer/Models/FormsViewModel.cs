using UTMDTE_WEB.Models;

namespace UTMDTE_WEB.Areas.Lecturer.Models
{
    public class FormsViewModel
    {
        public List<Form>? Forms { get; set; }

        public Course? Course { get; set; }

        public FormsViewModel(List<Form>? forms, Course? course)
        {
            Forms = forms;
            Course = course;
        }
    }

    public class FormViewModel
    {
        public Form? Form { get; set; }

        public int? CourseID { get; set; }

        public FormViewModel(Form? form, int? courseID)
        {
            Form = form;
            CourseID = courseID;
        }
    }
}
