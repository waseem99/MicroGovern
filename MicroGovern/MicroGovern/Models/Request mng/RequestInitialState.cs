using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Request_mng
{
    public class RequestInitialState : ARequestState
    {
        public override void Handle(Request req)
        {
            req.reqstate = new RequestInitialState();
        }
    }
}