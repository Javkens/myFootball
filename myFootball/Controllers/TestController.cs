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
        private ApplicationDbContext _context;

        public TestController()
        {
            _context = new ApplicationDbContext();

        }


        //aorawiec: do wykonania główny widok testów
        // GET: test
        public ActionResult Index()
        {
            IEnumerable<Test> variable = _context.Tests.ToList();
            return View(variable);

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