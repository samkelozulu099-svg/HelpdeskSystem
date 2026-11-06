using HelpdeskSystem.Data;
using HelpdeskSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskSystem.Controllers;

public class DashboardController : Controller
{
    private readonly HelpdeskContext _db;

    public DashboardController(HelpdeskContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new DashboardViewModel
        {
            Open = await _db.Tickets.CountAsync(t => t.Status == "Open"),
            InProgress = await _db.Tickets.CountAsync(t => t.Status == "In Progress"),
            Resolved = await _db.Tickets.CountAsync(t => t.Status == "Resolved"),
            Closed = await _db.Tickets.CountAsync(t => t.Status == "Closed"),
            Recent = await _db.Tickets.OrderByDescending(t => t.CreatedAt).Take(10).ToListAsync()
        };

        var done = await _db.Tickets
                            .Where(t => t.ResolvedAt != null)
                            .Select(t => new { t.CreatedAt, t.ResolvedAt })
                            .ToListAsync();

        vm.AvgResolutionHours = done.Count == 0
            ? 0
            : done.Average(t => (t.ResolvedAt!.Value - t.CreatedAt).TotalHours);

        return View(vm);
    }
}