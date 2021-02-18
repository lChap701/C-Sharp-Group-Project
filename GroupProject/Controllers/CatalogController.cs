using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Models;
using Microsoft.AspNetCore.Http;


namespace GroupProject.Views.Catalog
{
    /// <summary>
    /// Controller for the Course Catalog
    /// </summary>
    public class CatalogController : Controller
    {
        private readonly GroupProjectContext _context;

        /// <summary>
        /// Sets the data contained in a GroupProjectContext object to a new object
        /// </summary>
        /// <param name="context">Represents a GroupProjectContext object</param>
        public CatalogController(GroupProjectContext context)
        {
            _context = context;
        }

        // GET: Catalog
        /// <summary>
        /// Displays the Index view (the Catalog Page)
        /// </summary>
        /// <param name="search">Represents the value to search for</param>
        /// <param name="online">Represents the type of class to filter by</param>
        /// <returns>Returns the view that will be displayed with courses</returns>
        public async Task<IActionResult> Index(string search, bool online)
        { 
            var courses = await _context.Courses.ToListAsync();

            ViewData["Search"] = search;
            ViewData["Online"] = online;

            // Retrieves the value in the "admin" key
            ViewBag.Admin = bool.Parse(HttpContext.Session.GetString("admin"));

            // Checks if the search string is not null or empty
            if (!string.IsNullOrEmpty(search))
            {
                courses = courses.Where(c => c.CourseID.Contains(search) || c.CourseName.Contains(search)).ToList();
            }

            // Checks if only online class should be displayed
            if (online)
            {
                courses = courses.Where(c => c.Online == online).ToList();
            }


            return View(courses);
        }

        // GET: Catalog/Details/5
        /// <summary>
        /// Displays the Details view
        /// </summary>
        /// <param name="id">Represents the course ID of a selected course</param>
        /// <returns>Returns the view that is supposed to be displayed with a course</returns>
        public async Task<IActionResult> Details(string id)
        {
            // Checks if no ID is found
            if (id == null)
            {
                return NotFound();
            }

            // Attempts to find the course with the same ID as "id"
            var courses = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseID == id);

            // Checks if no course is found
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // GET: Catalog/Create
        /// <summary>
        /// Displays the Create view
        /// </summary>
        /// <returns>Returns the view</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Attempts to create a new course
        /// </summary>
        /// <param name="courses">Represents the course that was submitted</param>
        /// <returns>Returns the view that is suppose to be displayed with a course (when errors occur) or redirects to the Index view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,CourseName,Credits,Online")] Courses courses)
        {
            // Checks if any errors occurred
            if (ModelState.IsValid)
            {
                _context.Add(courses);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(courses);
        }

        // GET: Catalog/Edit/5
        /// <summary>
        /// Displays the Edit view
        /// </summary>
        /// <param name="id">Represents the course ID of the selected course</param>
        /// <returns>Returns the view that is suppose to be displayed with a course</returns>
        public async Task<IActionResult> Edit(string id)
        {
            // Checks if no ID is found
            if (id == null)
            {
                return NotFound();
            }

            // Attempts to find the course with the same ID as "id"
            var courses = await _context.Courses.FindAsync(id);

            // Checks if no course is found
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Attempts to update a selected course
        /// </summary>
        /// <param name="id">Represents the course ID of the selected course</param>
        /// <param name="courses">Represents the course that should be updated</param>
        /// <returns>Returns the view that is suppose to be displayed with a course (when errors occur) or redirects to the Index view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CourseID,CourseName,Credits,Online")] Courses courses)
        {
            // Checks if the "id" doesn't match the course ID
            if (id != courses.CourseID)
            {
                return NotFound();
            }

            // Checks if no errors occurred
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Checks if the course doesn't exist
                    if (!CoursesExists(courses.CourseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: Catalog/Delete/5
        /// <summary>
        /// Displays the Delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the view that is suppose to be displayed with a course</returns>
        public async Task<IActionResult> Delete(string id)
        {
            // Checks if no course ID is found
            if (id == null)
            {
                return NotFound();
            }

            // Attempts to find a course with the same ID as "id"
            var courses = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseID == id);

            // Checks if no course is found
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // POST: Catalog/Delete/5
        /// <summary>
        /// Attempts to delete a course from the course catalog
        /// </summary>
        /// <param name="id">Represents the course ID of a selected course</param>
        /// <returns>Returns the Index view</returns>
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var courses = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if a course exists
        /// </summary>
        /// <param name="id">Represents the course ID to search for</param>
        /// <returns>Returns a list of courses (returns null when not found)</returns>
        private bool CoursesExists(string id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
