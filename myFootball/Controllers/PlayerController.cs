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

        private ApplicationDbContext _context;

        public PlayerController()
        {
            _context = new ApplicationDbContext();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("player/save")]
        public ActionResult Save(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();

            return RedirectToAction("Index");
            //aorawiec: add information about succesfully added new player
        }

        // GET: Player
        public ActionResult Index()
        {
            var Players = _context.Players.ToList();
            return View(Players);
        }

        // GET: Test/id
        [Route("player/{id}")]
        public ActionResult Player(int id)
        {
            var player = _context.Players.FirstOrDefault(c => c.Id == id);
            return View(player);
        }

        [Route("player/new")]
        public ActionResult New()
        {
            var player = new Player();
            return View(player);

        }
    }
}