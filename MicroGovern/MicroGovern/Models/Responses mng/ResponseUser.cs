using MicroGovern.Models.Services_mng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Responses_mng
{
    public class ResponseUser
    {
        public int ID { get; set; }
        public virtual UserDetails providedService { get; set; }
    }
}