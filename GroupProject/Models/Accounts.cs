using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project8_GroupProject.Models
{
    /// <summary>
    /// Models for the Accounts table
    /// </summary>
    public class Accounts
    {
        /// <summary>
        /// Property for the AccID column in the Accounts table
        /// </summary>
        [Key]
        public int AccID { get; set; }

        /// <summary>
        /// Property for the Username column in the Accounts table
        /// </summary>
        [Required, StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        /// <summary>
        /// Property for the Email column in the Accounts table
        /// </summary>
        [Required, RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        /// <summary>
        /// Property for the Password column in the Accounts table
        /// </summary>
        [Required, RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }

        /// <summary>
        /// Property for the Confirm Password field that is used to be compared with the Password property
        /// </summary>
        [NotMapped, Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}