using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Coursework2.Controllers
{
	public class HomeController : Controller
	{
        private AppDBContent db;
        public HomeController(AppDBContent context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult tests(string username, string password, string users)
        {
            if (users == "player")
            {
                bool fg = false;
                var obj = db.Users.ToList();
                int ff = 0;
                foreach (var x in obj)
                {
                    if (x.username == username && x.password == password)
                    {
                        fg = true;
                        ff = x.Id;
                        break;
                    }

                }
                if (!fg)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("ListUsers", "Users", new { id = ff });
                }
            }
            else
            {
                bool fg = false;
                var obj = db.Leading.ToList();
                int ff = 0;
                foreach (var x in obj)
                {
                    if (x.username == username && x.password == password)
                    {
                        fg = true;
                        ff = x.Id;
                        break;
                    }

                }
                if (!fg)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("ListLeading", "Leading", new { id = ff });
                }
            }
        }

        public IActionResult Index()
		{
			return View();
		}
	}
}
