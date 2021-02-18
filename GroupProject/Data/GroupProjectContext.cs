using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Models;

namespace GroupProject.Data
{
    /// <summary>
    /// Used to define the "context" for our database
    /// </summary>
    public class GroupProjectContext : DbContext
    {
        /// <summary>
        /// Allows the program to interact with the database
        /// </summary>
        /// <param name="options">Represents the options that will be used by DbContext</param>
        public GroupProjectContext(DbContextOptions<GroupProjectContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Represents the Accounts table 
        /// </summary>
        public DbSet<Accounts> Accounts { get; set; }

        /// <summary>
        /// Represents the Courses table
        /// </summary>
        public DbSet<Courses> Courses { get; set; }
    }
}
