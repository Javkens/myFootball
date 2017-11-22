using myFootball.Models;
using myFootball.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myFootball.Class;
using System.Xml;

namespace myFootball.Controllers
{
    public class KindOfTestController : Controller
    {

        private ApplicationDbContext _context;

        public KindOfTestController()
        {
            _context = new ApplicationDbContext();

        }


        public ActionResult Index()
        {

            IEnumerable<KindOfTest> variable = _context.KindOfTests.ToList();
            return View(variable);

        }


        [Route("kindoftest/new")]
        public ActionResult New()
        {

            KindOfTestCreate create = new KindOfTestCreate();
            create.AllDyscyplines = _context.Dyscyplines.ToList();

            return View(create);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("kindoftest/new")]
        [MultipleButton(Name = "new", Argument = "creating")]
        public ActionResult New(KindOfTestCreate creating)
        {


            //dodaj do dyscyplines nową wartość
            DyscyplineUnit newdyscypline = (from d in _context.Dyscyplines
                                            join u in _context.Units on d.UnitId equals u.Id
                                            where d.Id == creating.NewDyscypline.Id
                                            select new DyscyplineUnit { Dyscypline = d, Unit = u }).Single();
            creating.Dyscyplines.Add(newdyscypline);
            creating.NewDyscypline = new Dyscypline();
            creating.AllDyscyplines = _context.Dyscyplines.ToList();
            creating.CheckAndRefresh();

            return View(creating);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("kindoftest/new")]
        [MultipleButton(Name = "new", Argument = "save")]
        public ActionResult Save(KindOfTestCreate create)
        {
            //save to database
            _context.KindOfTests.Add(create.KindOfTest);
            _context.SaveChanges();
            _context.Entry(create.KindOfTest).Reload();

            //save to xml
            SaveToXml(create);


            return RedirectToAction("Index");
        }


        private void SaveToXml(KindOfTestCreate create)
        {

            string path = string.Format("{0}/{1}{2}", Server.MapPath("/XML"), create.KindOfTest.Id.ToString() + create.KindOfTest.Name, ".xml");

            XmlDocument xmldoc = new XmlDocument();
            XmlDeclaration decl = xmldoc.CreateXmlDeclaration("1.0", "UTF-16", "");
            xmldoc.InsertBefore(decl, xmldoc.DocumentElement);
            XmlElement RootNode = xmldoc.CreateElement("KindOfTest");
            RootNode.SetAttribute("Id", create.KindOfTest.Id.ToString());
            RootNode.SetAttribute("Name", create.KindOfTest.Name);
            xmldoc.AppendChild(RootNode);

            foreach (var d in create.Dyscyplines)
            {
                XmlElement childNode = xmldoc.CreateElement("Dyscypline");
                childNode.SetAttribute("Id", d.Dyscypline.Id.ToString());
                childNode.SetAttribute("Name", d.Dyscypline.Name);
                childNode.SetAttribute("UnitId", d.Unit.Id.ToString());
                childNode.SetAttribute("UnitType", d.Unit.Type);
                RootNode.AppendChild(childNode);
            }

            xmldoc.Save(path);
        }
    }
}