using myFootball.Models;
using myFootball.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myFootball.Controllers
{
    public class DyscyplineController : Controller
    {

        private ApplicationDbContext _context;

        public DyscyplineController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {

            return View();

        }


        [Route("dyscypline/new")]
        public ActionResult New()
        {

            var units = _context.Units.ToList();
            var dyscyplineunits = new DyscyplineUnits
            {

                Dyscypline = new Dyscypline(),
                Units = units
            };
            return View(dyscyplineunits);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("dyscypline/save")]
        public ActionResult Save(Dyscypline dyscypline)
        {

            _context.Dyscyplines.Add(dyscypline);
            _context.SaveChanges();

            _context.Entry(dyscypline).Reload();

            return RedirectToAction("Index");
            //aorawiec: add information about succesfully added new group
        }

    }
}