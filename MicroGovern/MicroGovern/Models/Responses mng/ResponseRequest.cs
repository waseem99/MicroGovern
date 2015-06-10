using MicroGovern.Models.Services_mng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MicroGovern.Models.Request_mng;

namespace MicroGovern.Models.Responses_mng
{
    public class ResponseRequest
    {
        public int ID { get; set; }
        public virtual  Request providedService { get; set; }
    }
}