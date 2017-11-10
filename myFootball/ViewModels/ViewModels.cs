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
}