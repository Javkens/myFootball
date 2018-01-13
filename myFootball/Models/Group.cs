using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFootball.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public Group()
        {
            Id = -1;
            Name = "Brak nazwy grupy";
            City = "Brak miejscowości";
        }
    }
}
