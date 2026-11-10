using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models;

public class Proposal
{
    public int Id { get; set; }

    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }

    [Required, StringLength(150)]
    public string CourseName { get; set; } = "";

    [Required]
    public string ProposalType { get; set; } = "Create";   // Create / Delete

    [Required]
    public string Status { get; set; } = "Pending";
}