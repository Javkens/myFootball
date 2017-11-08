using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myFootball.Models;

namespace myFootball.Models
{
    public class GroupController : Controller
    {
        private ApplicationDbContext _context;


        public GroupController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Group
        public ActionResult Index()
        {
            var Groups = _context.Groups.ToList();
            return View(Groups);
        }


        [Route("group/{id}")]
        public ActionResult Group(int id)
        {
            var group = _context.Groups.FirstOrDefault(c => c.Id == id);
            return View(group);
        }


        [Route("group/new")]
        public ActionResult New()
        {
            var group = new Group();
            return View(group);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("group/save")]
        public ActionResult Save(Group group)
        {

            _context.Groups.Add(group);
            _context.SaveChanges();

            _context.Entry(group).Reload();

            return RedirectToAction("Index");
            //aorawiec: add information about succesfully added new group
        }
    }
}