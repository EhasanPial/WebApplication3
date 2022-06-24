using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                new Employee
                {
                    Id = 1,
                    Name = "Marry",
                    Department = Dept.HR,
                    Email = "mark@g.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jon",
                    Department = Dept.IT,
                    Email = "jon@g.com"
                }

                );
        }
    }
}
