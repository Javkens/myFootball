using myFootball.ViewModels;
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

        public GroupDto Group { get; set; }

        //probably not nessessary
       // public Group Group { get; set; }
    }

    public class TestDto
    {


        public int Id { get; set; }
        public string Name { get; set; }

        public string Date { get; set; }

        public string City { get; set; }

        public int KindOfTestID { get; set; }
        public KindOfTestDto KindOfTest { get; set; }

        public string GroundType { get; set; }
    }

    public class KindOfTestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string XMLDefintion { get; set; } //probabbly unneccesery
    }

    public class TestResultForPlayerDto
    {
        public string Name { get; set; }
        public List<Score> Scores = new List<Score>();

    }
}