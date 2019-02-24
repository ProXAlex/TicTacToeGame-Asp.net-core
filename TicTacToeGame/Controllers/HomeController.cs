using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToeGame.Infrastructure;
using TicTacToeGame.Models;

namespace TicTacToeGame.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //// Получаем данные сессии либо тут, либо во фронтэнде(site.js) расскоментировать Init() и закоментить это
            //var Controller = new GameController();
            //Controller.ControllerContext = ControllerContext;
            //var result = Controller.Init();
            var field = HttpContext.Session.GetJson<Field>("Field");

            return View(field ?? new Field());
            
        }

        public IActionResult NewGame()
        {
            var field = HttpContext.Session.GetJson<Field>("Field");
            field.NewGame();
            field.IsBotEnabled = false;
            HttpContext.Session.SetJson("Field", field);
            return RedirectToAction("Index");
        }
        public IActionResult NewGameWithBot()
        {
            var field = HttpContext.Session.GetJson<Field>("Field");
            field.NewGame();
            field.IsBotEnabled = true;
            HttpContext.Session.SetJson("Field", field);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ResetScores()
        {
            var field = HttpContext.Session.GetJson<Field>("Field");
            field.ResetScores();
            HttpContext.Session.SetJson("Field", field);
            return RedirectToAction("Index");
        }

    }
}
