using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data;
using Coursework2.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coursework2.Controllers
{
    public class QuestionController : Controller
    {
        private AppDBContent db;
        public QuestionController(AppDBContent context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult addQuestion(string question_text, string answer, string сomment, string author, string packages, string idLeading)
        {

            db.Questions.Add(new Questions { Id = db.Questions.ToList().Count + 1, QuestionText = question_text, Answer = answer, Comment = сomment, Author = author, IdPackage = Convert.ToInt32(packages)});
            db.SaveChanges();
            return RedirectToAction("ListQuestion", "Question", new { idLeading = idLeading });
        }

        [HttpPost]
        public IActionResult addPackage(string name_of_package, string package_editor, DateTime datetime, string idLeading)
        {

            db.PackageOfQuestions.Add(new PackageOfQuestions {Id = db.PackageOfQuestions.ToList().Count + 1, Name = name_of_package, PackageEditor = package_editor, DateOfCreation = datetime});
            db.SaveChanges();
            return RedirectToAction("ListQuestion", "Question", new { idLeading = idLeading });
        }

        public IActionResult ListQuestion(string idLeading)
        {
            var objToView1 = db.Questions.ToList();
            var objToView2 = db.PackageOfQuestions.ToList();
            var tupleModel = new Tuple<List<Questions>, List<PackageOfQuestions>,string>(objToView1, objToView2, idLeading);
            return View(tupleModel);
        }





        public IActionResult EditingQuestion(string idQuestion, string idLeading)
        {
            var objToView1 = db.Questions.Where(u => u.Id == Convert.ToInt32(idQuestion)).ToList();
            var objToView2 = db.PackageOfQuestions.ToList();
            var tupleModel = new Tuple<List<Questions>, List<PackageOfQuestions>, string>(objToView1, objToView2,idLeading);
            return View(tupleModel);
        }

        public IActionResult SaveQuestion(string question_text, string answer, string сomment, string author, string packages, string idQuestion, string idLeading)
        {
            Questions question = new Questions { Id = Convert.ToInt32(idQuestion), Answer = answer, Author = author, Comment = сomment, QuestionText = question_text, IdPackage = Convert.ToInt32(packages) };
            db.Entry(question).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListQuestion", "Question", new { idLeading = idLeading });
        }


        public IActionResult DellQuestion(string idQuestion, string idLeading)
        {
            Questions question = db.Questions.Where(u => u.Id == Convert.ToInt32(idQuestion)).First();
            db.Entry(question).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("ListQuestion", "Question", new { idLeading = idLeading });
        }



        [HttpPost]
        public IActionResult EditingPackage(string idPackage, string idLeading)
        {
            var objToView2 = db.PackageOfQuestions.Where(u => u.Id == Convert.ToInt32(idPackage)).ToList();
            var tupleModel = new Tuple<List<PackageOfQuestions>, string>(objToView2, idLeading);
            return View(tupleModel);
        }

        [HttpPost]
        public IActionResult SavePackage(string name_of_package, string package_editor, DateTime datetime, string idPackage, string idLeading)
        {
            PackageOfQuestions Package = new PackageOfQuestions { Id = Convert.ToInt32(idPackage), DateOfCreation = datetime, PackageEditor = package_editor, Name = name_of_package};
            db.Entry(Package).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListQuestion", "Question", new { idLeading = idLeading });
        }

        [HttpPost]
        public IActionResult DellPackage(string idPackage, string idLeading)
        {
            PackageOfQuestions Package = db.PackageOfQuestions.Where(u => u.Id == Convert.ToInt32(idPackage)).First();
            db.Entry(Package).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("ListQuestion", "Question", new { idLeading = idLeading });
        }

    }
}
