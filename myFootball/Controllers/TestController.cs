using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myFootball.Models;
using myFootball.ViewModels;
using System.Xml;

namespace myFootball.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext _context;

        public TestController()
        {
            _context = new ApplicationDbContext();

        }


        public ActionResult Index()
        {
            IEnumerable<Test> variable = _context.Tests.ToList();
            return View(variable);

        }


        [Route("test/new")]
        public ActionResult New()
        {
            var AddTestVar = new TestAddViewModel { Test = new Test(), KindOfTests = _context.KindOfTests.ToList() };
            return View(AddTestVar);

        }


        // GET: Test/id
        [Route("test/{id}")]
        public ActionResult Test(int id)
        {

            TestRenderModel testRender = new TestRenderModel(id, _context);

            return View(testRender);
        }
    }
}