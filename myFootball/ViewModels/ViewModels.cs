using myFootball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    //dyscypline/index
}