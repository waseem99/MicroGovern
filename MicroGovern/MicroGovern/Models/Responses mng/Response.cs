using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Responses_mng
{
    public class Response
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Bid Posted Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BidPosted { get; set; }

        [Required]
        [MinLength(100)]
        public string Proposal { get; set; }

        [Required]
        [Display(Name = "Proposed Price")]
        public decimal ProposedPrice { get; set; }

        [Display(Name = "Suitable Time Range")]
        public TimeSpan ProposedWorkTimeRange { get; set; }

        public Response()
        {

        }
    }

    //Database Model
    public class ResponseDBContext : DbContext
    {
        public DbSet<Response> responses { get; set; }
    }
}