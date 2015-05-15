using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MicroGovern.Models.Services_Management
{
    public class Service
    {
        private int ID { get; set; }
        private string Title { get; set; }
        private DateTime DateAdded { get; set; }
        private string Details { get; set; }

        public Service()
        {

        }
        public class ServiceDBContext : DbContext
        {
            public DbSet<Service> Services { get; set; }
        }
    }
}