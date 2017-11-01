using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myFootball.Models;


namespace myFootball.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }


        [Route("player/mainview")]
        public ActionResult MainView()
        {
            var MainView = new Player(0); //aorawiec: tutaj bedzie trzeba zainicjalizować tylko tablicę ze wszystkimi testami. nie wiem czy nie utworzyc do tego osobnej klasy
            return View(MainView);

        }


        // GET: Test/id
        [Route("player/{id}")]
        public ActionResult Player(int id)
        {
            var player = new Player(id);
            return View(player);
        }
    }
}