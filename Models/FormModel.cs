namespace Courses_app.Models
{
    public class SuggestCourse
    {
        public string CourseName { get; set; }
        public string AuthorName { get; set; }
        public string CourseCode { get; set; }
        public string DateStarting { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
    }
    public class CourseInfo
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string DateStarting { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
    }


    public class ContactForm
    {
        public string Email { get; set; }
        public string Query { get; set; }
        public string HearAbout { get; set; }
    }

    public class SignUpForm
    {
        public string StudentName { get; set; }
        public string Course { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string GetDate { get; set; }
    }
}