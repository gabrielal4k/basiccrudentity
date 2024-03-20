using Microsoft.EntityFrameworkCore;
using SampleApi3.DTO;

namespace SampleApi3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<DTOStudent> Students { get; set; }
        public DbSet<DTOSystemRole> SystemRole { get; set; }
    }
}
