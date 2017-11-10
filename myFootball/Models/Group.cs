using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFootball.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Player[] Players { get; set; }


        //aorawiec: dodanie konstruktora który wypełnia obiekt player wszystkimi zawodnikami danej grupy.

    }
}