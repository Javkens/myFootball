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

        public DateTime Date { get; set; } = DateTime.Now;

        public string City { get; set; }

        public int KindOfTestId { get; set; }
        public KindOfTest KindOfTest { get; set; }
 
        public string GroundType { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int DyscyplineId { get; set; }
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
    }
}