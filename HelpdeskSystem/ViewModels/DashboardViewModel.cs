using HelpdeskSystem.Models;

namespace HelpdeskSystem.ViewModels;

public class DashboardViewModel
{
    public int Open { get; set; }
    public int InProgress { get; set; }
    public int Resolved { get; set; }
    public int Closed { get; set; }
    public double AvgResolutionHours { get; set; }
    public List<Ticket> Recent { get; set; } = new();
}