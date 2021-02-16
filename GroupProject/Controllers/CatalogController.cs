using GroupProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly GroupProjectContext _context;

        public CatalogController(GroupProjectContext context)
        {
            _context = context;
        }

        // GET: /Catalog
        /// <summary>
        /// Displays the Catalog view/page (Index.cshtml)
        /// </summary>
        /// <param name="search">Represents the course that the user is looking for</param>
        /// <returns>Returns the view that should be displayed with courses</returns>
        public async Task<IActionResult> Index(string search)
        {
            var courses = _context.Courses.ToListAsync();

            if (!string.IsNullOrEmpty(search))
            {
                //courses = courses.Where(c => c.Name.Contains(search) || c.CourseID.Contains(search)).ToList();
            }

            return View(courses);
        }
    }
}
