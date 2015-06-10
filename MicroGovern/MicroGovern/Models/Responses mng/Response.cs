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

        [Display(Name = "Suitable Start Time")]
        public TimeSpan ProposedWorkStartTime { get; set; }

        [Display(Name = "Suitable End Time")]
        public TimeSpan ProposedWorkEndTime { get; set; }

        public virtual ResponseUser respuser { get; set; }

        public virtual ResponseRequest respreq { get; set; }

        public Response()
        {
            BidPosted = DateTime.Now;
        }

        public virtual void Operation()
        {

        }
    }

    //Database Model
    public class ResponseDBContext : DbContext
    {
        public DbSet<Response> responses { get; set; }
    }
}