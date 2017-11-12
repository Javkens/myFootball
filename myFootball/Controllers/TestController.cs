using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myFootball.Models;

namespace myFootball.Controllers
{
    public class TestController : Controller
    {
        //aorawiec: do wykonania główny widok testów
        // GET: test
        [Route("test/mainview")]
        public ActionResult MainView()
        {
            var MainView = new Test(); //aorawiec: tutaj bedzie trzeba zainicjalizować tylko tablicę ze wszystkimi testami. nie wiem czy nie utworzyc do tego osobnej klasy
            return View(MainView);

        }


        // GET: Test/id
        [Route("test/{id}")]
        public ActionResult Test(int id)
        {
            var test = new Test();
            return View(test);
        }
    }
}