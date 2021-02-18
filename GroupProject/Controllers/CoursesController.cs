using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GroupProject.Data;
using GroupProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;

namespace GroupProject.Controllers
{
    /// <summary>
    /// The main controller for this project
    /// </summary>
    public class CoursesController : Controller
    {
        private readonly GroupProjectContext _context;
        private static readonly Regex regex = new Regex(@"[^a-zA-Z]");  // used to double check results

        /// <summary>
        /// Sets the data contained in a GroupProjectContext object to a new object
        /// </summary>
        /// <param name="context">Represents a GroupProjectContext object</param>
        public CoursesController(GroupProjectContext context)
        {
            _context = context;
        }

        // GET: Courses
        /// <summary>
        /// Displays the Index view (the Catalog Page)
        /// </summary>
        /// <returns>Returns the view</returns>
        public IActionResult Index()
        {
            return View();
        }

        /* 
         * The Login and SignUp views/pages use concepts from: 
         * https://dev.to/skipperhoa/login-and-register-using-asp-net-mvc-5-3i0g
         */

        // GET: Courses/Login
        /// <summary>
        /// Displays the Login page/view
        /// </summary>
        /// <returns>Returns the view</returns>
        public IActionResult Login()
        {
            return View();
        }

        // POST: Courses/Login
        /// <summary>
        /// Attempts to log the user in to the Course Catolog
        /// </summary>
        /// <param name="user">Represents the email address or username that was submitted</param>
        /// <param name="password">Represents the password that was submitted</param>
        /// <returns>Returns the view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            // Checks if any errors occurred
            if (ModelState.IsValid)
            {
                var data = _context.Accounts.Where(s => s.Username.Equals(username.Trim()) && s.Password.Equals(password.Trim())).ToList();

                // Checks if an account was found
                if (data.Count > 0)
                {
                    var user = _context.Accounts.Where(s => s.Username.Equals(username.Trim()) && s.Password.Equals(password.Trim())).ToList().Single();

                    // Double checks fields
                    if (regex.Replace(username, string.Empty) == regex.Replace(user.Username, string.Empty))
                    {
                        if (regex.Replace(password, string.Empty) == regex.Replace(user.Password, string.Empty))
                        {
                            HttpContext.Session.SetString("admin", user.IsAdmin.ToString());

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Error = "Password is incorrect";

                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Username is incorrect";

                        return View();
                    }

                }
                else
                {
                    ViewBag.Error = "Account was not found";

                    return View();
                }
            }

            return View();
        }

        // GET: Courses/Signup
        /// <summary>
        /// Displays the Signup page/view
        /// </summary>
        /// <returns>Returns the view</returns>
        public IActionResult Signup()
        {
            return View();
        }

        // POST: Courses/Signup
        /// <summary>
        /// Attempts to sign up users for the Course Catolog
        /// </summary>
        /// <param name="_user">Represents the data that the user submitted</param>
        /// <returns>Returns the view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Signup(Accounts _user)
        {
            // Check if any errors occur
            if (ModelState.IsValid)
            {
                var check = _context.Accounts.Where(a => a.Email.Equals(_user.Email) || a.Username.Equals(_user.Username)).ToList();

                // Checks if an email address and username was found 
                if (check.Count == 0)
                {
                    _context.Accounts.Add(_user);
                    _context.SaveChanges();

                    return RedirectToAction("Login");
                }
                else
                {
                    var errorCheck = _context.Accounts.Where(a => a.Email.Equals(_user.Email) || a.Username.Equals(_user.Username)).Single();

                    // Double check fields
                    if (regex.Replace(_user.Username, string.Empty) != regex.Replace(errorCheck.Username, string.Empty))
                    {
                        if (regex.Replace(_user.Email, string.Empty) != regex.Replace(errorCheck.Email, string.Empty))
                        {
                            _context.Accounts.Add(_user);
                            _context.SaveChanges();

                            return RedirectToAction("Login");
                        }
                        else
                        {
                            ViewBag.Error = "Email address should be unique";

                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Username should be unique";

                        return View();
                    }
                }
            }

            return View();
        }
    }
}