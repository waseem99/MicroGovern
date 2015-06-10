using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Request_mng
{
    public abstract class ARequestState
    {
        public abstract void Handle(Request req);
    }
}