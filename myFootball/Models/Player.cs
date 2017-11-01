using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFootball.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        //public int WittySystemId { get; set; } aorawiec: question that is nessesery
        public string Address { get; set; }

        public Player (int _id)
        {
            Id = _id;
            //rest of parameters should be getted from database. actually default
            FirstName = "Jan";
            SecondName = "Andrzej";
            LastName = "Duda!";
            Birthdate = "1994-08-12";
            Address = "Lipnica Wielka";

        }
        public Player(int _id, int _group_id, string _first, string _second, string _last, string _birth, string _address)
        {

            Id = _id;
            GroupId = _group_id;
            FirstName = _first;
            SecondName = _second;
            LastName = _last;
            Birthdate = _birth;
            Address = _address;

        }
    }
}