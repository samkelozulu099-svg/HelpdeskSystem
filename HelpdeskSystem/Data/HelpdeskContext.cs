using HelpdeskSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskSystem.Data;

public class HelpdeskContext : DbContext
{
    public HelpdeskContext(DbContextOptions<HelpdeskContext> options) : base(options) { }

    public DbSet<Ticket> Tickets { get; set; }
}