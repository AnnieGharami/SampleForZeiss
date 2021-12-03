using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Platform.ApplicationServices.Contexts;
using Platform.ApplicationServices.Data.Entities;

namespace Platform.ApplicationServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            using (var ctx = new EmployeeDbContext())
            {
                //var stud = new Student() { StudentName = "Bill" };
                var emp = new Employee()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    RoleId = 1,
                    DepartmentId = 1,
                    CreatedAt = DateTime.Now
                };
                ctx.Employees.Add(emp);
                _ = new Employee()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Simmers",
                    RoleId = 1,
                    DepartmentId = 2,
                    CreatedAt = DateTime.Now
                };
                ctx.Employees.Add(emp);
                emp =new Employee()
                  {
                      Id = 3,
                      FirstName = "Anthony",
                      LastName = "Dewar",
                      RoleId = 2,
                      DepartmentId = 1,
                      CreatedAt = DateTime.Now
                  };

                ctx.Employees.Add(emp);
                ctx.SaveChanges();
            }
            //using (var scope = host.Services.CreateScope())
            //{
            //    try
            //    {
            //        var context = scope.ServiceProvider.GetService<EmployeeDbContext>();
            //        context.Database.EnsureDeleted();
            //        context.Database.Migrate();
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}
            //host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
