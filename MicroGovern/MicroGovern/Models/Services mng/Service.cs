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
        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

        //ICON URL

        [Required]
        [MinLength(100)]
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