namespace UTMDTE_WEB.Models
{
    public class Course
    {
        public int? ID { get; set; }

        public int? Section { get; set; }

        public string? Code { get; set; }

        public string? Title { get; set; }

        public Boolean? IsChecked { get; set; }

        public Form? Form { get; set; }

        public int LecturerID { get; set; }

        public int? SessionID { get; set; }

        //test
        //test 2
    }
}
