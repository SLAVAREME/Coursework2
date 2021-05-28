using Coursework2.Data;
using Coursework2.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework2.Controllers
{
    public class UsersController : Controller
    {

        private AppDBContent db;
        public UsersController(AppDBContent context)
        {
            db = context;
        }

        public IActionResult addGame(int addGame, int id)
        {
            db.ClientSession.Add(new ClientSession { IdUser = id, IdSession = addGame});
            db.SaveChanges();
            return RedirectToAction("ListUsers", "Users", new { id = id });
        }

        public IActionResult ListUsersString(string id)
        {
            return RedirectToAction("ListUsers", "Users", new { id = Convert.ToInt32(id)});
        }


        public IActionResult ListUsers(int id)
        {
            var objToView1 = new List<Users> { };
            var objToView2 = db.GameSession.ToList();
            var objToView3 = new List<ClientSession> { };
            var objToView4 = db.PackageOfQuestions.ToList();

            var obj = db.Users.ToList();
            foreach (var x in obj)
            {
                if (x.Id == id)
                {
                    objToView1.Add(x);
                    break;
                }
            }

            var obj2 = db.ClientSession.ToList();
            foreach (var x in obj2)
            {
                if (x.IdUser == id)
                {
                    objToView3.Add(x);
                }
            }
            var tupleModel = new Tuple<List<Users>, List<GameSession> ,List<ClientSession>, List<PackageOfQuestions>>(objToView1, objToView2, objToView3, objToView4);
            return View(tupleModel);
        }

    }
}
