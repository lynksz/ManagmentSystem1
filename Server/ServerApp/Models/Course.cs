namespace ServerApp.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Semester { get; set; } = string.Empty;

        public int TeacherID { get; set; }

        public Teacher? Teacher { get; set; }
    }
}