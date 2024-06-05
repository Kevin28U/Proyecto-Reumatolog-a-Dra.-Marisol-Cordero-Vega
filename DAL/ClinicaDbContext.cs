
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ClinicaDbContext : DbContext
    {


        public ClinicaDbContext()
        {

        }


        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }

    }
}
