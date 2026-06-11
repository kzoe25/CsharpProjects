using Microsoft.EntityFrameworkCore;
using CarInsurance.Models;

namespace CarInsurance.Data
{
    public class InsureeContext : DbContext
    {
        public InsureeContext(DbContextOptions<InsureeContext> options)
            : base(options)
        {
        }

        public DbSet<Insuree> Insurees { get; set; }
    }
}
