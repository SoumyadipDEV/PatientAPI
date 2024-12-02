using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PatientAPI.Data
{
    public class PatientDbContextFactory : IDesignTimeDbContextFactory<PatientDbContext>
    {
        public PatientDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PatientDbContext>();
            optionsBuilder.UseSqlServer("Server=SOUMYADIPBOOK\\SQLEXPRESS;Database=Suraksha_TestAPI;Trusted_Connection=True;");
            return new PatientDbContext(optionsBuilder.Options);
        }
    }
}
