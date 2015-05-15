using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MicroGovern.Models.Services_Management.Request_mng
{
    public class Request
    {
        public Request ()
        {

        }

        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime RequestIniated { get; set; }
        public string Details { get; set; }
        public decimal MinRate { get; set; }
        public decimal MaxRate { get; set; }
    }

    public class RequestDBContext : DbContext
    {
        public DbSet<Request> requests { get; set; }
    }
}