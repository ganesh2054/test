using CollegeManagement.Models;
using CollegeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

using System.IO;
using System.Linq;


namespace CollegeManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _Studentrepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly StudentDbContext _Context;
        int Value;
        public StudentController(StudentRepository _studentrepo, IHostingEnvironment hostingEnvironment,StudentDbContext _context)
        {
            _Studentrepo = _studentrepo;
            this.hostingEnvironment = hostingEnvironment;
            _Context = _context;
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        public IActionResult Attendencee()
        {
      
            return View();
        }
        public IActionResult DeleteStudent(int id)
        {
            _Studentrepo.Delete(id);
            return RedirectToAction("StudentList");


        }
        [HttpPost]
        public IActionResult Attendencee(Student ss)
        {
            // var students = _Context.Students
            ////.Where(s => s.Name=="Ganesh")
            //.ToList();

            Value = Convert.ToInt32(ss.Faculty);
                
            return View();

        }
        public IActionResult AttendenceStatus()
        {
            // var students = _Context.Students
            ////.Where(s => s.Name=="Ganesh")
            //.ToList();
            
            var students = _Context.Students.FromSql($"select*  from Students where Faculty={Value}").ToList();
            return View(students);
  
        }
        [HttpPost]
        public IActionResult Index(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string UniqueFileName = UploadFile(model);
                Student newstudent = new Student
                {
                    Name = model.Name,
                    Address = model.Address,
                    Email = model.Email,
                    Gender = model.Gender,
                    Birthday = model.Birthday,
                    Phon = model.Phon,
                    Faculty = model.Faculty,
                    PhotoPath = UniqueFileName

                };
                _Studentrepo.Add(newstudent);
                return RedirectToAction("StudentList", new { id = newstudent.id });
            }

            return View();
        }
        public IActionResult StudentList()
        {

            var model = _Context.Students.FromSql($"select*  from Students").ToList();
            return View(model);
        }
        public IActionResult StudentDetails(int? id)
        {
            Student model = _Studentrepo.GetStudent(id ?? 1);

            return View(model);
        }
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Student student = _Studentrepo.GetStudent(id);
            StudentEditViewModel editviewModel = new StudentEditViewModel
            {
                id = student.id,
                Name = student.Name,
                Address = student.Address,
                Email = student.Email,
                Gender = student.Gender,
                Birthday = student.Birthday,
                Phon = student.Phon,
                Faculty = student.Faculty,
                ExistingPhotoPath = student.PhotoPath
            };
            return View(editviewModel);
        }

        [HttpPost]
        public IActionResult EditStudent(StudentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = _Studentrepo.GetStudent(model.id);
                student.id = model.id;
                student.Name = model.Name;
                student.Address = model.Address;
                student.Email = model.Email;
                student.Gender = model.Gender;
                student.Birthday = model.Birthday;
                student.Phon = model.Phon;
                student.Faculty = model.Faculty;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "img", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);

                    }
                    student.PhotoPath = UploadFile(model);

                }

                _Studentrepo.Update(student);
                return RedirectToAction("StudentList");
            }
            return View(model);

        }

      private string UploadFile(StudentCreateViewModel model)
        {
            string uniquefileName = null;
            if (model.Photo != null)
            {
                string Uplodefile = Path.Combine(hostingEnvironment.WebRootPath, "img");
                uniquefileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(Uplodefile, uniquefileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

            }

            return uniquefileName;
        }
    }
}
