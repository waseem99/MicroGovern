﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Request_mng
{
    public abstract class ARequestState
    {
        [Key]
        public int ID { get; set; }
        public abstract void Handle(Request req);
    }
}