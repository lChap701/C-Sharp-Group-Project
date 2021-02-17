using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GroupProject.Data;

namespace GroupProject.Models
{
    /// <summary>
    /// Add default data to all tables in the DB
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// Adds default data to he Accounts table when no data is present
        /// </summary>
        /// <param name="serviceProvider">Used to provide custom support to objects</param>
        public static void InitializeAccounts(IServiceProvider serviceProvider)
        {
            using var context = new GroupProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GroupProjectContext>>());

            // Checks if any accounts are in the DB
            if (context.Accounts.Any())
            {
                return; // means that the DB has been seeded
            }

            context.Accounts.AddRange(
                new Accounts
                {
                    Username = "user1",
                    Email = "email@gmail.com",
                    Password = "0B1A253CCD667BB075C2AC0C59C0F283",
                    IsAdmin = true
                },
                new Accounts
                {
                    Username = "user2",
                    Email = "example@gmail.com",
                    Password = "09F376919F350C1F1D72F7C1E3C0E43B",
                    IsAdmin = true
                },
                new Accounts
                {
                    Username = "user3",
                    Email = "example2@gmail.com",
                    Password = "8475DD410845B2DCEE863938B867B8E2",
                    IsAdmin = false
                }
            );

            context.SaveChanges();
        }

        /// <summary>
        /// Adds default data to the Courses table when no data is present
        /// </summary>
        /// <param name="serviceProvider">Used to provide custom support to objects</param>
        public static void InitializeCourses(IServiceProvider serviceProvider)
        {
            using var context = new GroupProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GroupProjectContext>>());

            // Checks if any courses are in the DB
            if (context.Courses.Any())
            {
                return; // means that the DB has been seeded
            }

            context.Courses.AddRange(

            );
        }
    }
}
