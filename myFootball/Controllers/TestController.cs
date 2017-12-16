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
            var testRender = new TestRenderModel();
            var test = new Test();
            var KindOfTest = new KindOfTest();
            var Dyscypline = new Dyscypline();

            test = _context.Tests.FirstOrDefault(t => t.Id == id);
            KindOfTest = _context.KindOfTests.FirstOrDefault(k => k.Id == test.KindOfTestID);


            //load xml
            string path = string.Format("{0}/{1}{2}", Server.MapPath("/XML"), KindOfTest.Id.ToString() + KindOfTest.Name, ".xml");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            XmlNodeList nodes = xmldoc.GetElementsByTagName("Dyscypline");
            foreach (XmlNode n in nodes)
            {
                int id_xml;
                id_xml = Int32.Parse(n.Attributes["Id"].Value);
                Dyscypline = _context.Dyscyplines.FirstOrDefault(d => d.Id == id_xml);
                testRender.ListOfDyscyplines.Add(Dyscypline);
            }
            testRender.Test = test;

            return View(testRender);
        }
    }
}