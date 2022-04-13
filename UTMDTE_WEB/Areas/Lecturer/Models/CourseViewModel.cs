using UTMDTE_WEB.Models;

namespace UTMDTE_WEB.Areas.Lecturer.Models
{
    public class CourseViewModel
    {
        public List<Course>? Courses { get; set; }

        public CourseViewModel(List<Course>? courses)
        {
            Courses = courses;
        }
    }
}
