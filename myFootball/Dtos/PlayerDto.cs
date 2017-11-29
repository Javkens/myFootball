using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace myFootball.Dtos
{
    public class PlayerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Birthday { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public int GroupId { get; set; }
        //probably not nessessary
       // public Group Group { get; set; }
    }
}