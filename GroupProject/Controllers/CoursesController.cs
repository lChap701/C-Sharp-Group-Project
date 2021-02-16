using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project8_GroupProject.Data;
using Project8_GroupProject.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Project8_GroupProject.Controllers
{
    /// <summary>
    /// The main controller for this project
    /// </summary>
    public class CoursesController : Controller
    {
        private readonly GroupProjectContext _context;

        // GET: /Courses
        /// <summary>
        /// Displays the Home page/view (Index.cshtml)
        /// </summary>
        /// <returns>Returns the view</returns>
        public IActionResult Index()
        {
            return View();
        }

        /* 
         * The Login and SignUp views/pages use concepts from: 
         * - https://dev.to/skipperhoa/login-and-register-using-asp-net-mvc-5-3i0g
         */

        // GET: /Courses/Login
        /// <summary>
        /// Displays the Login page/view
        /// </summary>
        /// <returns>Returns the view</returns>
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Courses/Login
        /// <summary>
        /// Attempts to log the user in to the Course Catolog
        /// </summary>
        /// <param name="user">Represents the email address or username that was submitted</param>
        /// <param name="password">Represents the password that was submitted</param>
        /// <returns>Returns the view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(string user, string password)
        {
            // Checks if any errors occurred
            if (ModelState.IsValid)
            {
                password = EncryptPassword(password);
                var data = _context.Accounts.Where(s => (s.Email.Equals(user) || s.Username.Equals(user)) && s.Password.Equals(password)).ToList();

                // Checks if an account was found
                if (data.Count > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag["Error"] = "Account was not found";
                    return RedirectToAction("Login");
                }
            }

            return View();
        }

        // GET: /Courses/SignUp
        /// <summary>
        /// Displays the SignUp page/view
        /// </summary>
        /// <returns>Returns the view</returns>
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: /Courses/SignUp
        /// <summary>
        /// Attempts to sign up users for the Course Catolog
        /// </summary>
        /// <param name="_user">Represents the data that the user submitted</param>
        /// <returns>Returns the view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SignUp(Accounts _user)
        {
            // Check if any errors occur
            if (ModelState.IsValid)
            {
                var check = _context.Accounts.Where(a => a.Email != _user.Email);

                // Checks if an email address was found 
                if (check != null)
                {
                    _user.Password = EncryptPassword(_user.Password);
                    _context.Accounts.Add(_user);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag["Error"] = "Email address is not unique";
                    return View();
                }
            }

            return View();
        }

        /// <summary>
        /// Encrypts sensitive data (such as passwords)
        /// </summary>
        /// <param name="psw">Represents the password that should be encrypted</param>
        /// <returns>Returns the encrypted password</returns>
        public static string EncryptPassword(string psw)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(psw);
            byte[] targetData = md5.ComputeHash(fromData);
            string hash = null;

            // Encrypts the data
            for (int i = 0; i < targetData.Length; i++)
            {
                hash += targetData[i].ToString("x2");
            }

            return hash;
        }

        // Insert method for the Courses view here
    }
}
