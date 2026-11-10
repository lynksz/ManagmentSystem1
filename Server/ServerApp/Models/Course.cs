using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models;

public class Course
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string Name { get; set; } = "";

    public string? Description { get; set; }

    [Required, StringLength(50)]
    public string Semester { get; set; } = "";

    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}