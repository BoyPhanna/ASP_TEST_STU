using Microsoft.AspNetCore.Mvc;
using TestASP2.Data;
using TestASP2.Models;

namespace TestASP2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _db.Students;
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if(ModelState.IsValid) { 
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            Console.WriteLine("Edit Student by id");
            if (id == null || id==0)
            {
                return NotFound();
            }
            var student = _db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var student= _db.Students.Find(id);
            if (student == null)
            {
                return NotFound();  
            }
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
