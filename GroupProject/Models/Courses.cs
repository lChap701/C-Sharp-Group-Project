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
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Course ID"), Key]
        public string CourseID { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public bool Online { get; set; }
    }
}
