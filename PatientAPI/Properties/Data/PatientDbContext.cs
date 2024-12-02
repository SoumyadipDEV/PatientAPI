using Microsoft.EntityFrameworkCore;

namespace PatientAPI.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .ToTable("SDPL_PatientMaster");  // Map the entity to the correct table name
        }
    }

    public class Patient
    {
        public int SLNo { get; set; }
        public string PatientID { get; set; }
        public string PatirntName { get; set; }
        public string PatientMobNo { get; set; }
        public string? PatientEmail { get; set; }
        public string? Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public bool PatientActive { get; set; }
    }
}
