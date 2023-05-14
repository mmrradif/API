using Microsoft.EntityFrameworkCore;
using PracticalAPI.Database_Models;

namespace PracticalAPI.Database_Context
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContext):base(dbContext)
        {
            
        }

        public DbSet<Employee> Employees => Set<Employee>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=CoreEmployeeDb;Trusted_Connection=True");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                
                new Employee
                {
                    Id= 1,
                    FirstName="Md. Mahbur Rahman",
                    LastName="Radif",
                    BirthDate= DateTime.Parse("11-22-1996"),
                    Salary=50000,
                    IsManager= true
                }
                
            );
        }

    }
}
