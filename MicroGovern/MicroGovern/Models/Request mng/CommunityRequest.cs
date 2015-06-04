using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Request_mng
{
    public class CommunityRequest: ARequest
    {
        [Required]
        [MinLength(10)]
        [Display(Name = "Title")]
        public string CommunityName { get; set; }

    }
}