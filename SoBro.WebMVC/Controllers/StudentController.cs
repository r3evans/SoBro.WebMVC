using Microsoft.AspNet.Identity;
using SoBro.Data;
using SoBro.Models.Models;
using SoBro.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SoBro.WebMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var model = new StudentListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(StudentCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateStudentService();
            if (service.CreateStudent(model))
            {
                TempData["SaveResult"] = "The student was created";
                return RedirectToAction("Index");
            };
            {
                ModelState.AddModelError("", "Student could not be created.");
                return View(model);
            }

        }
        public StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var studentService = new StudentService(userId);
            return studentService;
        }

        public ActionResult Edit(Guid id)
        {
            var service = CreateStudentService();
            var detail = service.GetStudentById(id);
            var model =
                new StudentEdit
                {
                    StudentId = detail.StudentId,
                    FirstName = detail.FirstName,
                    Age = detail.Age,
                    Active = detail.Active
                };
            return View(model);
        }

        [System.Web.Mvc.ActionName("Delete")]
        public ActionResult Delete(Guid id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);
            return View(model);
        }
    }
}