using Microsoft.EntityFrameworkCore;

namespace ShiftLoggerAPI.Models
{
    public class ShiftDbContext : DbContext
    {
        public DbSet<Shift> Shifts { get; set; }

        public ShiftDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
