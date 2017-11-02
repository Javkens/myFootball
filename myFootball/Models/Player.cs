using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myFootball.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Imię i Nazwisko")]
        public string Name { get; set; }

        [Display(Name = "Data urodzenia")]
        public string Birthday { get; set; }

        //public int WittySystemId { get; set; } aorawiec: question that is nessesery

        [Display(Name = "Adres")]
        public string Address { get; set; }


        public Player (int _id)
        {
            Id = _id;
            //rest of parameters should be getted from database. actually default
            Name = "Artur Orawiec";
            Birthday = "1994-08-12";
            Address = "Lipnica Wielka";

        }
        public Player(int _id, string _name, string _birth, string _address)
        {

            Id = _id;
            Name = _name;
            Birthday = _birth;
            Address = _address;

        }
    }
}