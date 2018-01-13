using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using myFootball.Models;

namespace myFootball.ViewModels
{
    public class ViewGroupIndex : Models.Group
    {
        public int NumberOfPlayers { get; set; }

        ViewGroupIndex()
        {
            Id = 0;
            Name = "Brak nazwy grupy";
            City = "Brak miejscowości";
            NumberOfPlayers = -1;
        }
    }
}