using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFootball.Models
{
    public class Defines
    {
        public string SQL_CONNECTION_STRING { get; set; }

        Defines()
        {
            SQL_CONNECTION_STRING = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=D:\\Projekty\\myFootball\\myFootball\\myFootball\\App_Data\\aspnet-myFootball-20171029025114.mdf;Initial Catalog=aspnet-myFootball-20171029025114;Integrated Security=True";
        }

    }
}