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
    }
}
