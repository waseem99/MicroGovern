using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using MicroGovern.Models.Request_mng;

namespace MicroGovern.Models.Request_mng
{
    public class Request
    {
        public ARequestState reqstate { get; set; }

        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name = "Title")]
        public string Title { get; set; }

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
            this.RequestIniated = DateTime.Now;
           // this.WorkDueDate = DateTime.Now;
        }

        // Request User Mapping 
        public virtual RequestUser requser { get; set; }

        //Request Service Mapping
        private ICollection<RequestService> _reqServices;
        public virtual ICollection<RequestService> reqServices
        {
            get { return _reqServices ?? (_reqServices = new Collection<RequestService>()); }
            protected set { _reqServices = value; }
        }


    }

    //Database Model
    public class RequestDBContext : DbContext
    {
        public DbSet<Request> requests { get; set; }
    }
}