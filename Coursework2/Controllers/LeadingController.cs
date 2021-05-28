using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Interfaces;
using Coursework2.Data.Models;
using Coursework2.Data;

namespace Coursework2.Controllers
{
    public class LeadingController : Controller
    {
        private AppDBContent db;
        public LeadingController(AppDBContent context)
        {
	        db = context;
        }

        [HttpPost]
        public IActionResult addGame(string name_of_game, DateTime datetime, string packages , int id)
        {
            db.GameSession.Add(new GameSession {Id = 0, IdLeading = id, NameOfGame = name_of_game, Start = datetime, IdPackageQuestions = Convert.ToInt32(packages) });
            db.SaveChanges();
            return RedirectToAction("ListLeading", "Leading", new { id = id });
        }

        public IActionResult ListLeadingString(string idLeading)
        {

            return RedirectToAction("ListLeading", "Leading", new { id = Convert.ToInt32(idLeading) });
        }

        public IActionResult ListLeading(int id)
        {
            var objToView1 = new List<Leading> { };
            var objToView2 = new List<GameSession> { };
            var objToView3 = db.PackageOfQuestions.ToList();
            var obj = db.Leading.ToList();
            foreach (var x in obj)
            {
                if (x.Id == id)
                {
                    objToView1.Add(x);
                    break;
                }
            }

            var obj2 = db.GameSession.ToList();
            foreach (var x in obj2)
            {
                if (x.IdLeading == id)
                {
                    objToView2.Add(x);
                }
            }

            var tupleModel = new Tuple<List<Leading>, List<GameSession>, List<PackageOfQuestions>>(objToView1, objToView2, objToView3);
            return View(tupleModel);
        }

    }
}
