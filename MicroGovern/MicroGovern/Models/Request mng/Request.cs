using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MicroGovern.Models.Services_Management.Request_mng
{
    public class Request
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        //chaged the file
        [Display(Name = "Request Iniated")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequestIniated { get; set; }

        [Required]
        [MinLength(100)]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Minimum Price")]
        public decimal MinRate { get; set; }

        [Display(Name = "Maximum Price")]
        public decimal MaxRate { get; set; }

        [Display(Name = "Work Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WorkDueDate { get; set; }

        [Display(Name = "Suitable Time Range")]
        public TimeSpan WorkableTimeRange { get; set; }

        [Display(Name = "Image")]
        public string PicURL { get; set; }

        public Boolean BidsVisibility { get; set; }

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