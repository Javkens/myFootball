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

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Zdjęcie zawodnika")]
        public string Image { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }


    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}