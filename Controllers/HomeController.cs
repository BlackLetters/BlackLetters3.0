using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Biblioteca.Services.Interfaces;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IRepositoryWrapper repo;

        public HomeController(ILogger<HomeController> logger)//, IRepositoryWrapper repo)
        {
            _logger = logger;
            //this.repo = repo;
        }

        public IActionResult Index()
        {
            //var book = repo.Book.FindAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<ViewResult> DisplayBooks()
        //{
        //    DataTable table = new DataTable();

        //    table.Columns.Add("Student");
        //    table.Columns.Add("Course");
        //    table.Columns.Add("Course Materials");
        //    table.Columns.Add("Seminary Materials");
        //    table.Columns.Add("Laboratory Materials");

        //    var userId = userManager.GetUserId(User);
        //    var student = bookService.GetDetailsById(userId);

        //    var badges = (from course in context.Courses
        //                  from attendance in context.CourseAttendances
        //                  from material in context.CourseMaterials
        //                  where student.StudentId == attendance.StudentId &&
        //                        course.CourseId == attendance.CourseId &&
        //                        course.CourseId == material.CourseId
        //                  select new
        //                  {
        //                      student.FirstName,
        //                      course.Name,
        //                      material.LinkCourseMaterial,
        //                      material.LinkSeminarMaterial,
        //                      material.LinkLaboratoryMaterial
        //                  }).ToList();

        //    foreach (var schoolSituation in badges)
        //    {
        //        table.Rows.Add(schoolSituation.FirstName, schoolSituation.Name, schoolSituation.LinkCourseMaterial,
        //                        schoolSituation.LinkSeminarMaterial, schoolSituation.LinkLaboratoryMaterial);
        //    }

        //    ViewData["table"] = table;

        //    return View("CourseMaterials");
        //}
    }
}
