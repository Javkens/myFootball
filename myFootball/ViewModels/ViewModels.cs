using myFootball.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using myFootball.Controllers;

namespace myFootball.ViewModels
{
    public class PlayerGroup
    {
        public Player Player { get; set; }
        public Group Group { get; set; }
    }

    public class PlayerEditViewModel
    {
        public Player Player { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }


    public class GroupIndexView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int NumberOfPlayers { get; set; }
    }


    //dyscypline/add
    public class DyscyplineUnits
    {
        public Dyscypline Dyscypline { get; set; }
        public IEnumerable<Unit> Units { get; set; }
    }



    public class DyscyplineUnit
    {
        public Dyscypline Dyscypline { get; set; }
        public Unit Unit { get; set; }
    }



    public class KindOfTestBody
    {
        //all data to destinity save
        public KindOfTest KindOfTest { get; set; }
        public List<DyscyplineUnit> Dyscyplines { get; set; }
        public int NumberOfDyscyplines { get; set; }


        public KindOfTestBody()
        {
            KindOfTest = new KindOfTest();
            Dyscyplines = new List<DyscyplineUnit>();
            NumberOfDyscyplines = 0;
        }


        public void SaveToXml(string path)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlDeclaration decl = xmldoc.CreateXmlDeclaration("1.0", "UTF-16", "");
            xmldoc.InsertBefore(decl, xmldoc.DocumentElement);
            XmlElement RootNode = xmldoc.CreateElement("KindOfTest");
            RootNode.SetAttribute("Id", KindOfTest.Id.ToString());
            RootNode.SetAttribute("Name", KindOfTest.Name);
            xmldoc.AppendChild(RootNode);

            foreach(var d in Dyscyplines)
            {
                XmlElement childNode = xmldoc.CreateElement("Dyscypline");
                childNode.SetAttribute("Id", d.Dyscypline.Id.ToString());
                childNode.SetAttribute("Name", d.Dyscypline.Name);
                childNode.SetAttribute("UnitId", d.Unit.Id.ToString());
                RootNode.AppendChild(childNode);
            }
        
            xmldoc.Save(path);
        }
    }



    public class KindOfTestCreate : KindOfTestBody
    {
        //add handler to new dyscypline from check box and all dyscyplines to view on /kindoftest/new
        public Dyscypline NewDyscypline { get; set; }
        public IEnumerable<Dyscypline> AllDyscyplines {get; set;}


        public KindOfTestCreate() => new KindOfTest();


        public void CheckAndRefresh()
        {
            NumberOfDyscyplines = Dyscyplines.Count();
        }
    }
}