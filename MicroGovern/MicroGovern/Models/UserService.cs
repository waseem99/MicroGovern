using MicroGovern.Models.Services_mng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models
{
    public class UserService
    {
        public int ID { get; set; }
        public virtual Service providedService{ get; set;}
    }
}