using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models;

public class Teacher
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Вкажіть ім'я"), StringLength(100)]
    public string Name { get; set; } = "";

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = "";

    [Required]
    public string PasswordHash { get; set; } = "";

    public List<Course> Courses { get; set; } = new();
    public List<Proposal> Proposals { get; set; } = new();
}