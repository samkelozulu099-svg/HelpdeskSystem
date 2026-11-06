using System.ComponentModel.DataAnnotations;

namespace HelpdeskSystem.Models;

public class Ticket
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string Title { get; set; } = "";

    [Required]
    public string Description { get; set; } = "";

    public string Category { get; set; } = "Software";   // Hardware, Software, Network
    public string Priority { get; set; } = "Low";        // Low, Medium, High
    public string Status { get; set; } = "Open";         // Open, In Progress, Resolved, Closed

    public string CreatedBy { get; set; } = "";          // user's name or email
    public string? AssignedTo { get; set; }              // technician's name, empty = unassigned

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? ResolvedAt { get; set; }
}