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
    public class DyscyplineUnit
    {
        public Dyscypline Dyscypline { get; set; }
        public Unit Unit { get; set; }
    }


    public class DyscyplineUnits
    {
        public Dyscypline Dyscypline { get; set; }
        public IEnumerable<Unit> Units { get; set; }
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