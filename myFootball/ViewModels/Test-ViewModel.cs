using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myFootball.Models;

namespace myFootball.ViewModels
{
    public class TestAddViewModel
    {
        public Test Test { get; set; }

        public IEnumerable<KindOfTest> KindOfTests { get; set; }
    }

    public class TestRenderModel
    {
        public Test Test { get; set; }
        public List<Dyscypline> ListOfDyscyplines = new List<Dyscypline>();

    }
}
