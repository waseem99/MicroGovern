using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections;

namespace MicroGovern.Models.Services_Management.Request_mng
{
    public class Request
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime RequestIniated { get; set; }
        public string Details { get; set; }
        public decimal MinRate { get; set; }
        public decimal MaxRate { get; set; }
        public int NumDays;
        public int StartTime;
        public int EndTime;
        public string PicURL;
        public Boolean BidsVisibility;
        //public ArrayList <Service> CategList { get; set; }

        public Request()
        {

        }
    }

    //Database Model
    public class RequestDBContext : DbContext
    {
        public DbSet<Request> requests { get; set; }
    }
}