namespace ServerApp.Models;

public class Proposal
{
    public int ID { get; set; }
    public int TeacherID { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string ProposalType { get; set; } = "Create"; // 'Create' або 'Delete'
    public string Status { get; set; } = "Pending";

    public Teacher? Teacher { get; set; }
}