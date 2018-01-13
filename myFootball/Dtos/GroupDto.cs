using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFootball.Dtos
{

    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
    
    public class GroupIndexDto : GroupDto
    {
        public int NumberOfPlayers { get; set; }
    }
}