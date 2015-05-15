using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MicroGovern.Models.Services_Management
{
    public class Service
    {
        [Key] public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public string Details { get; set; }

        public Service()
        {

        }
    }
    public class ServiceDBContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
    }
}