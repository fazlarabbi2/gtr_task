using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    DepartmentId = 101,
                    DesignationId = 201,
                    Email = "john.doe@example.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    DepartmentId = 102,
                    DesignationId = 202,
                    Email = "jane.smith@example.com"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Emily Johnson",
                    DepartmentId = 103,
                    DesignationId = 203,
                    Email = "emily.johnson@example.com"
                },
                new Employee
                {
                    Id = 4,
                    Name = "Michael Brown",
                    DepartmentId = 104,
                    DesignationId = 204,
                    Email = "michael.brown@example.com"
                },
                new Employee
                {
                    Id = 5,
                    Name = "Sarah Davis",
                    DepartmentId = 105,
                    DesignationId = 205,
                    Email = "sarah.davis@example.com"
                },
                new Employee
                {
                    Id = 6,
                    Name = "David Wilson",
                    DepartmentId = 106,
                    DesignationId = 206,
                    Email = "david.wilson@example.com"
                },
                new Employee
                {
                    Id = 7,
                    Name = "Laura Martinez",
                    DepartmentId = 107,
                    DesignationId = 207,
                    Email = "laura.martinez@example.com"
                },
                new Employee
                {
                    Id = 8,
                    Name = "James Anderson",
                    DepartmentId = 108,
                    DesignationId = 208,
                    Email = "james.anderson@example.com"
                },
                new Employee
                {
                    Id = 9,
                    Name = "Linda Thomas",
                    DepartmentId = 109,
                    DesignationId = 209,
                    Email = "linda.thomas@example.com"
                },
                new Employee
                {
                    Id = 10,
                    Name = "Robert Moore",
                    DepartmentId = 110,
                    DesignationId = 210,
                    Email = "robert.moore@example.com"
                }
            );
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
