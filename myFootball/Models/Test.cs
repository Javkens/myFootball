using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFootball.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdKindOfTest { get; set; }
        public string Date { get; set; }
        public int IDGroup { get; set; }
        public string Data { get; set; } //aoraiwec tutaj tablica z danymi testów?

        public Test(int _id)
        {
            Id = _id;
            //temp (use default values) in futere this will be getting data from database
            Name = "Jablonka";
            IdKindOfTest = 2;
            Date = "2017-09-12";
            IDGroup = 4;


            //aorawiec get data from database
        }
        
        //aorawiec: do zrobienia konstruktory

    }
}