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
    public class ResultsController : Controller
    {
        private AppDBContent db;
        public ResultsController(AppDBContent context)
        {
            db = context;
        }

        public IActionResult ListResults(string idGameSession, string idLeading)
        {
            var GameSession = db.GameSession.Where(u => u.Id == Convert.ToInt32(idGameSession)).ToList();
            var ListQuestions = db.Questions.Where(u => u.IdPackage == GameSession[0].Id).ToList();
            var CurrQuestion = db.CurrentQuestion.ToList().Where(u => u.IdSession == Convert.ToInt32(idGameSession)).ToList();
            var ListUsers = db.Users.ToList();
            var CurrAnswer = db.CurrentAnswer.Where(u => u.IdSession == Convert.ToInt32(idGameSession)).ToList();

            var tupleModel = new Tuple< List<GameSession> , List<CurrentQuestion> , List<Questions> , List<Users>, List<CurrentAnswer>, string  ,string>
                                                (GameSession, CurrQuestion, ListQuestions, ListUsers, CurrAnswer, idGameSession, idLeading);
            return View(tupleModel);
        }
    }
}
