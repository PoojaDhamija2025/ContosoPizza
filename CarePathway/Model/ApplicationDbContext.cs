using Microsoft.EntityFrameworkCore;

namespace CarePathway.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Observation> Observation { get; set; }
        public DbSet<PatientsObservationsTbl> PatientsObservationsTbl { get; set; }
    }
}
