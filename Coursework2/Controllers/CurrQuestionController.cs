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
    public class CurrQuestionController : Controller
    {
        private AppDBContent db;
        public CurrQuestionController(AppDBContent context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult LeadingToStart(string idGameSession, string idPackage, string idLeading)
        {
            var tupleModel = new Tuple<string, string, string>(idGameSession, idPackage, idLeading);
            return View(tupleModel);
        }

        public IActionResult NextQuestions(string idGameSession, string idPackage, string idLeading)
        {
            var listQuestions = db.Questions.Where(u => u.IdPackage == Convert.ToInt32(idPackage)).ToList();
            var CurrQuestion = db.CurrentQuestion.ToList().Where(u => u.IdSession == Convert.ToInt32(idGameSession));
            int idQuest = 0;
            string s1 = "";

            if (listQuestions.Count() > CurrQuestion.Count())
            {
                idQuest = listQuestions[CurrQuestion.Count()].Id;
                s1 = listQuestions[CurrQuestion.Count()].QuestionText;
                db.CurrentQuestion.Add(new CurrentQuestion { Id = db.CurrentQuestion.ToList().Count() + 1, IdSession = Convert.ToInt32(idGameSession), IdQuestion = idQuest, Question = s1 });
                db.SaveChanges();
                return RedirectToAction("CurrQuestionLeading", "CurrQuestion", new { idGameSession = idGameSession, idPackage = idPackage, idLeading = idLeading });
            }
            else
            {
                return RedirectToAction("CurrQuestionFinishLeading", "CurrQuestion", new { idLeading = idLeading, idGameSession = idGameSession });
            }
        }

        public IActionResult StartTimeQuestions(string idGameSession, string idPackage, string idLeading)
        {
            CurrentQuestion CurrQuestions = db.CurrentQuestion.Where(u => u.IdSession == Convert.ToInt32(idGameSession)).OrderByDescending(u => u.Id).First();
            CurrQuestions.StartQuestion = DateTime.Now;
            CurrQuestions.EndQuestion = DateTime.Now.AddSeconds(70);
            db.Entry(CurrQuestions).State = EntityState.Modified;
            db.SaveChanges();

            var listQuestions = db.Questions.Where(u => u.IdPackage == Convert.ToInt32(idPackage)).ToList();
            var CurrQuestion = db.CurrentQuestion.Where(u => u.IdSession == Convert.ToInt32(idGameSession)).OrderByDescending(u => u.Id).ToList();
            var tupleModel = new Tuple<string, string, List<CurrentQuestion>, string, List<Questions>>(idGameSession, idPackage, CurrQuestion, idLeading, listQuestions);
            return View(tupleModel);
        }

        public IActionResult EndTimeQuestions(string idGameSession, string idPackage, string idLeading)
        {
            CurrentQuestion CurrQuestion = db.CurrentQuestion.Where(u => u.IdSession == Convert.ToInt32(idGameSession)).OrderByDescending(u => u.Id).First();
            CurrQuestion.EndQuestion = DateTime.Now;
            db.Entry(CurrQuestion).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("NextQuestions", "CurrQuestion", new { idGameSession = idGameSession, idPackage = idPackage, idLeading = idLeading });
        }

        public IActionResult CurrQuestionLeading(string idGameSession, string idPackage, string idLeading)
        {
            var CurrQuestion = db.CurrentQuestion.Where(u => u.IdSession == Convert.ToInt32(idGameSession)).OrderByDescending(u => u.Id).ToList();
            var tupleModel = new Tuple<string, string, List<CurrentQuestion>, string>(idGameSession, idPackage, CurrQuestion, idLeading);
            return View(tupleModel);
        }

        public IActionResult CurrQuestionFinishLeading(string idLeading, string idGameSession)
        {
            var ff = db.CurrentAnswer.Where(u => u.IdSession == Convert.ToInt32(idGameSession)).AsEnumerable().GroupBy(u => u.IdUsers).ToList();
            List<ResultsTable> restab = new List<ResultsTable> { };

            foreach (var x in ff)
            {
                var g = db.Users.Where(u => u.Id == Convert.ToInt32(x.Key)).ToList();
                var h = db.CurrentAnswer.Where(u => u.IdSession == Convert.ToInt32(idGameSession) && u.IdUsers == g[0].Id).ToList();
                int count = 0;
                foreach (var i in h)
                {
                    count += i.Credited;
                }
                restab.Add(new ResultsTable { NameUsers = g[0].Name, CountPoints = count });
            }
            var restab2 = restab.OrderByDescending(u => u.CountPoints).ToList();
            var tupleModel = new Tuple<string, List<ResultsTable>,string>(idLeading, restab2, idGameSession);
            return View(tupleModel);
        }










        public IActionResult CurrQuestionUser(string idGameSession, string idUsers, string idPackage)
        {
            var listQuestions = db.Questions.Where(u => u.IdPackage == Convert.ToInt32(idPackage)).ToList();
            var CurrQuestion = db.CurrentQuestion.ToList().Where(u => u.IdSession == Convert.ToInt32(idGameSession)).OrderByDescending(u => u.Id).ToList();

            if (listQuestions.Count() >= CurrQuestion.Count())
            {
                if (CurrQuestion.Count() == 0)
                {
                    return RedirectToAction("CurrQuestionUsersStartWait", "CurrQuestion", new { idGameSession = idGameSession, idUsers = idUsers, idPackage = idPackage });
                }
                else
                {
                    if (CurrQuestion[0].StartQuestion != new DateTime() && CurrQuestion[0].EndQuestion > DateTime.Now)
                    {
                        var tupleModel = new Tuple<List<CurrentQuestion>, string, string, string>(CurrQuestion, idGameSession, idUsers, idPackage);
                        return View(tupleModel);
                    }
                    else 
                    {
                        if (CurrQuestion[0].StartQuestion == new DateTime() && CurrQuestion[0].EndQuestion == new DateTime())
                        {
                            return RedirectToAction("CurrQuestionUsersWait", "CurrQuestion", new { idGameSession = idGameSession, idUsers = idUsers, idPackage = idPackage });
                        }
                        else 
                        {
                            return RedirectToAction("CurrQuestionUsersWaitAnswer", "CurrQuestion", new { idGameSession = idGameSession, idUsers = idUsers, idPackage = idPackage });
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("CurrQuestionFinishUsers", "CurrQuestion", new { idUsers = idUsers, idGameSession = idGameSession });
            }
        }


        public IActionResult CurrQuestionUsersAnswer(string idGameSession, string idUsers, string idPackage, string Answer)
        {
            var CurrQuestion = db.CurrentQuestion.Where(u => u.IdSession == Convert.ToInt32(idGameSession)).OrderByDescending(u => u.Id).ToList();
            int fg = 0;
            var d = db.Questions.Where(u => u.Id == CurrQuestion[0].IdQuestion).ToList();
            if (d[0].Answer == Answer || d[0].Answer == Answer.ToLower() || d[0].Answer == Answer.ToUpper())
            {
                fg = 1;
            }
            if (CurrQuestion[0].Questions?.Answer.ToUpper() == Answer.ToUpper() || CurrQuestion[0].Questions?.Answer.ToLower() == Answer.ToLower() || CurrQuestion[0].Questions?.Answer == Answer)
            {
                fg = 1;
            }
            db.CurrentAnswer.Add(new CurrentAnswer {IdSession = Convert.ToInt32(idGameSession), IdUsers = Convert.ToInt32(idUsers), IdCurrentQuestion = CurrQuestion[0].Id, Answer = Answer, Credited = fg});
            db.SaveChanges();
            return RedirectToAction("CurrQuestionUser", "CurrQuestion", new { idGameSession = idGameSession, idUsers = idUsers, idPackage = idPackage });
        }

        public IActionResult CurrQuestionUsersWait(string idGameSession, string idUsers, string idPackage)
        {
            var CurrQuestion = db.CurrentQuestion.ToList().Where(u => u.IdSession == Convert.ToInt32(idGameSession)).OrderByDescending(u => u.Id).ToList();
            var tupleModel = new Tuple<List<CurrentQuestion>, string, string, string>(CurrQuestion, idGameSession, idUsers, idPackage);
            return View(tupleModel);
        }

        public IActionResult CurrQuestionUsersWaitAnswer(string idGameSession, string idUsers, string idPackage)
        {
            var listQuestions = db.Questions.Where(u => u.IdPackage == Convert.ToInt32(idPackage)).ToList();
            var CurrQuestion = db.CurrentQuestion.ToList().Where(u => u.IdSession == Convert.ToInt32(idGameSession)).OrderByDescending(u => u.Id).ToList();
            var tupleModel = new Tuple<List<CurrentQuestion>, string, string, string,List<Questions>>(CurrQuestion, idGameSession, idUsers, idPackage, listQuestions);
            return View(tupleModel);
        }


        public IActionResult CurrQuestionUsersStartWait(string idGameSession, string idUsers, string idPackage)
        {
            var tupleModel = new Tuple<string, string, string>(idGameSession, idUsers, idPackage);
            return View(tupleModel);
        }


        public IActionResult CurrQuestionFinishUsers(string idUsers, string idGameSession)
        {
            var CurrAnswer = db.CurrentAnswer.ToList();
            var Users = db.Users.ToList();
            var GameSession = db.GameSession.ToList();

            var ff = db.CurrentAnswer.Where(u => u.IdSession == Convert.ToInt32(idGameSession)).AsEnumerable().GroupBy(u => u.IdUsers).ToList();
            List<ResultsTable> restab = new List<ResultsTable> { };

            foreach (var x in ff)
            {
                var g = db.Users.Where(u=>u.Id==Convert.ToInt32(x.Key)).ToList();
                var h = db.CurrentAnswer.Where(u => u.IdSession == Convert.ToInt32(idGameSession) && u.IdUsers== g[0].Id).ToList();
                int count = 0;
                foreach (var i in h)
                {
                    count += i.Credited;
                }
                restab.Add( new ResultsTable { NameUsers = g[0].Name, CountPoints = count});
            }
            var restab2 = restab.OrderByDescending(u=>u.CountPoints).ToList();
            var tupleModel = new Tuple<string, List<ResultsTable>>(idUsers, restab2);
            return View(tupleModel);
        }




    }
}
