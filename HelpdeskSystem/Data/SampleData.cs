using HelpdeskSystem.Models;

namespace HelpdeskSystem.Data;

public static class SampleData
{
    public static void Add(HelpdeskContext db)
    {
        if (db.Tickets.Any()) return;

        db.Tickets.Add(new Ticket { Title = "Printer offline", Description = "2nd floor printer", Category = "Hardware", Priority = "High", Status = "Open", CreatedBy = "user1" });
        db.Tickets.Add(new Ticket { Title = "Wi-Fi drops in lab", Description = "Drops every 10 min", Category = "Network", Priority = "Medium", Status = "In Progress", CreatedBy = "user2", AssignedTo = "Technician 1" });
        db.Tickets.Add(new Ticket { Title = "Install Office", Description = "New laptop", Category = "Software", Priority = "Low", Status = "Resolved", CreatedBy = "user3", AssignedTo = "Technician 2", CreatedAt = DateTime.Now.AddHours(-5), ResolvedAt = DateTime.Now });

        db.SaveChanges();
    }
}