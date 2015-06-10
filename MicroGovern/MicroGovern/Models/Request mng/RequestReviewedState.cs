using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Request_mng
{
    public class RequestReviewedState : ARequestState
    {
        public override void Handle(Request req)
        {
            req.reqstate = new RequestReviewedState();
        }
    }
}