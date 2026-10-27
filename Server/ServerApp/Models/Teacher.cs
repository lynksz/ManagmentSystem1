namespace ServerApp.Models;

public class Teacher
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public List<Course> Courses { get; set; } = new();
    public List<Proposal> Proposals { get; set; } = new();
}