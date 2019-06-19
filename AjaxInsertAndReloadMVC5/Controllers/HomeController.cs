using AjaxInsertAndReloadMVC5.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AjaxInsertAndReloadMVC5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();

            using (StudentDB2Context db = new StudentDB2Context())
            {
                students = db.Students.ToList();
            }

            return View(students);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(Student student)
        {
            if (student.StudentId > 0)
            {
                using (StudentDB2Context db = new StudentDB2Context())
                {
                    db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                using (StudentDB2Context db = new StudentDB2Context())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ReloadStudentDetails(int studentId)
        {
            Student student = new Student();

            using (StudentDB2Context db = new StudentDB2Context())
            {
                student = db.Students.Find(studentId);
            }

            // NewUpdateStudent is the partial view
            return PartialView("NewUpdateStudent", student);
        }


    }
}