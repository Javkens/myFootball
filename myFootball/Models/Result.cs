using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFootball.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int KindOfTestId { get; set; }
        public Player Player { get; set; }
        public int PlayerID { get; set; }
        public string Date { get; set; }
        public double Score { get; set; }

    }
}