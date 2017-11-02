﻿using System;
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

    }
}