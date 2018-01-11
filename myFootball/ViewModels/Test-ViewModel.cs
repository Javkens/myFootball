using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using myFootball.Models;

namespace myFootball.ViewModels
{
    public class TestAddViewModel
    {
        public Test Test { get; set; }

        public IEnumerable<KindOfTest> KindOfTests { get; set; }
    }

    public class TestRenderModel : Controller
    {
        public Test Test { get; set; }
        public List<Dyscypline> ListOfDyscyplines = new List<Dyscypline>();


        public TestRenderModel(Test t, List<Dyscypline> ld)
        {
            Test = t;
            ListOfDyscyplines = ld;

        }

        public TestRenderModel(int id, ApplicationDbContext _context)
        {
            Test test = new Test();
            KindOfTest KindOfTest = new KindOfTest();
            Dyscypline Dyscypline = new Dyscypline();

            test = _context.Tests.FirstOrDefault(t => t.Id == id);
            KindOfTest = _context.KindOfTests.FirstOrDefault(k => k.Id == test.KindOfTestId);


            //load xml
            string path = string.Format("{0}/{1}{2}", System.Web.Hosting.HostingEnvironment.MapPath("/XML"), KindOfTest.Id.ToString() + KindOfTest.Name, ".xml");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            XmlNodeList nodes = xmldoc.GetElementsByTagName("Dyscypline");
            foreach (XmlNode n in nodes)
            {
                int id_xml;
                id_xml = Int32.Parse(n.Attributes["Id"].Value);
                Dyscypline = _context.Dyscyplines.FirstOrDefault(d => d.Id == id_xml);
                ListOfDyscyplines.Add(Dyscypline);
            }

            Test = test;
        }

    }

    public class TestResultForPlayer
    {
        public Player Player { get; set; }
        public List<Score> Scores = new List<Score>();

        public TestResultForPlayer(Player player)
        {
            Player = player;
        }

    }

    public class Score
    {
        public int Id { get; set; } //id in dbo.Results
        public double ScoreResult { get; set; }

    }
}
