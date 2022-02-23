using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_name.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_name.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.RCBians.Any())
                {
                    context.RCBians.AddRange(new RCB()
                    {
                        Name = "Virat Kohli",
                        DOB = DateTime.Now,
                        Job = "Batsman",
                        Salary = "15cr"


                    },
                    new RCB()
                    {
                        Name = "maxwell",
                        DOB = DateTime.Now,
                        Job = "Batsman",
                        Salary = "10cr"

                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
