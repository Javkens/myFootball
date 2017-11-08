using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myFootball.Models;
using myFootball.ViewModels;
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
            var listgroups = _context.Groups.ToList();
            var playereditview = new PlayerEditViewModel
            {

                Player = new Player(),
                Groups = listgroups
            };

            return View(playereditview);

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
            if (Request.Files["Player.Image"].ContentLength > 0)
            {

                string extension = Path.GetExtension(Request.Files["Player.Image"].FileName);
                string path = string.Format("{0}/{1}{2}", Server.MapPath("/Images/Players"), player.Id, extension);

                Request.Files["Player.Image"].SaveAs(path);

                ViewData["Message"] = "File Uploaded Successfully";

            }

            return RedirectToAction("Index");
            //aorawiec: add information about succesfully added new player
        }
    }
}