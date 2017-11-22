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

            IEnumerable<PlayerGroup> query = (from p in _context.Players
                                         join g in _context.Groups on p.GroupId equals g.Id
                                         select new PlayerGroup { Player = p, Group = g }).ToList();

            return View(query);
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
            var playereditview = new PlayerEditViewModel { Player = new Player(), Groups = _context.Groups.ToList() };
            return View(playereditview);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("player/save")]
        public ActionResult Save(Player player, HttpPostedFileBase file)
        {
            //check if it's new player or only editing data of exist player
            if(player.Id == 0)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
                _context.Entry(player).Reload();
            } else
            {
                var query = $"UPDATE dbo.Players SET Name='{player.Name}', Address='{player.Address}', Birthday='{player.Birthday}', GroupId='{player.GroupId}' WHERE Id={player.Id}";
                _context.Database.ExecuteSqlCommand(query);
            }

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


        [Route("player/edit/{id}")]
        public ActionResult Edit(int id)
        {
            Player player = _context.Database.SqlQuery<Player>($"SELECT * FROM dbo.Players WHERE Players.Id = '{id}'").Single();
            var playereditview = new PlayerEditViewModel { Player = player, Groups = _context.Groups.ToList() };
            return View(playereditview);
        }
    }
}