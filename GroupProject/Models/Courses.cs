using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    /// <summary>
    /// Model for the Courses table
    /// </summary>
    public class Courses
    {
        /// <summary>
        /// Property for the CourseID column in the Courses table
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Course ID"), Key]
        public string CourseID { get; set; }

        /// <summary>
        /// Property for the CourseName column in the Courses table
        /// </summary>
        [Display(Name = "Course Name"), Required, StringLength(60, MinimumLength = 1)]
        public string CourseName { get; set; }

        /// <summary>
        /// Property for the Credits column in the Courses table
        /// </summary>
        [Required, Range(0, 4)]
        public int Credits { get; set; }

        /// <summary>
        /// Property for the Online column in the Courses table
        /// </summary>
        public bool Online { get; set; }
    }
}
