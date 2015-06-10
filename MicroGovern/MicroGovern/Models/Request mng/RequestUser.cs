using MicroGovern.Models.Services_mng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Request_mng
{
    public class RequestUser
    {
        public int ID { get; set; }
        public virtual UserDetails providedService { get; set; }
    }
}