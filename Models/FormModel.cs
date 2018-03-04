namespace Courses_app.Models
{
    public class AddCourseFormModel
    {
        public string CourseName { get; set; }
        public string AuthorName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string Price { get; set; }


        // needs price and author
    }

    public class ContactForm
    {
        public string Email { get; set; }
        public string Query { get; set; }
        public string HearAbout { get; set; }
    }

    public class FormModel
    {
        public string FirstName { get; set; }
    }
}