using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFootball.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        //public int WittySystemId { get; set; } aorawiec: question that is nessesery
        public string Address { get; set; }

        public Player (int _id)
        {
            Id = _id;
            //rest of parameters should be getted from database. actually default
            Name = "Artur Orawiec";
            Birthdate = "1994-08-12";
            Address = "Lipnica Wielka";

        }
        public Player(int _id, string _name, string _birth, string _address)
        {

            Id = _id;
            Name = _name;
            Birthdate = _birth;
            Address = _address;

        }
    }
}