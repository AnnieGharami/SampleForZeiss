using Microsoft.EntityFrameworkCore;
using Platform.ApplicationServices.Data.Entities;
using System;

namespace Platform.ApplicationServices.Contexts
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .HasData(
        //        new Employee()
        //        {
        //            Id = 1,
        //            FirstName = "John",
        //            LastName = "Doe",
        //            RoleId = 1,
        //            DepartmentId = 1,
        //            CreatedAt = DateTime.Now
        //        },
        //         new Employee()
        //         {
        //             Id = 2,
        //             FirstName = "Jane",
        //             LastName = "Simmers",
        //             RoleId = 1,
        //             DepartmentId = 2,
        //             CreatedAt = DateTime.Now
        //         },
        //          new Employee()
        //          {
        //              Id = 3,
        //              FirstName = "Anthony",
        //              LastName = "Dewar",
        //              RoleId = 2,
        //              DepartmentId = 1,
        //              CreatedAt = DateTime.Now
        //          });

        //    modelBuilder.Entity<Role>()
        //        .HasData(
        //        new Role()
        //        {
        //            Id = 1,
        //            Name = "Manager"
        //        },
        //          new Role()
        //          {
        //              Id = 2,
        //              Name = "System Engineer"
        //          },
        //           new Role()
        //           {
        //               Id = 3,
        //               Name = "Test Engineer"
        //           });
        //    modelBuilder.Entity<Department>()
        //        .HasData(
        //        new Department()
        //        {
        //            Id = 1,
        //            Name = "A1"
        //        },
        //          new Department()
        //          {
        //              Id = 2,
        //              Name = "B2"
        //          },
        //           new Department()
        //           {
        //               Id = 3,
        //               Name = "C3"
        //           });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
