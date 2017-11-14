using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myFootball.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int KindOfTestID { get; set; }
        public KindOfTest KindOfTest { get; set; }

        public string Date { get; set; }

        public int GroupID { get; set; }
        public Group Group { get; set; }

        public string GroundType { get; set; }
        
    }

    public class Result
    {
        public int Id { get; set; }

        public int PlayerID { get; set; }
        public Player Player { get; set; }

        public int ExamID { get; set; }

        public int DyscyplineID { get; set; }
        public Dyscypline Dyscypline { get; set; }

        public double Score { get; set; }

    }

    public class Dyscypline
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }

    public class Unit
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string TypeGenetive { get; set; }
        public string TypeShort { get; set; }

    }

    public class KindOfTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string XMLDefintion { get; set; } //probabbly unneccesery

        public KindOfTest()
        {
            Id = 0;
            Name = "brak nazwy";
            XMLDefintion = "empty xml";
        }
    }
}