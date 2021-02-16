using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GroupProject.Data;
using GroupProject.Models;

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
                    Password = "p@sSw0rD",
                    IsAdmin = 'Y'
                },
                new Accounts
                {
                    Username = "user2",
                    Email = "example@gmail.com",
                    Password = "p@sSw0rD12",
                    IsAdmin = 'Y'
                }
            );
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
