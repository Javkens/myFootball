using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myFootball.Models;
using System.IO;

namespace myFootball.Controllers
{
    public class PlayerController : Controller
    {

        private ApplicationDbContext _context;

        public PlayerController()
        {
            _context = new ApplicationDbContext();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("player/save")]
        public ActionResult Save(Player player, HttpPostedFileBase file)
        {
            
            _context.Players.Add(player);
            _context.SaveChanges();

            _context.Entry(player).Reload();

            //add image
            if (Request.Files["Image"].ContentLength > 0)
            {

                string extension = Path.GetExtension(Request.Files["Image"].FileName);
                string path = string.Format("{0}/{1}{2}", Server.MapPath("/Images/Players"), player.Id, extension);

                Request.Files["Image"].SaveAs(path);

                ViewData["Message"] = "File Uploaded Successfully";

            }

            return RedirectToAction("Index");
            //aorawiec: add information about succesfully added new player
        }
    }
}