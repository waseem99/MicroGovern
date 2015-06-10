using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Responses_mng
{
    public class ResponseADecorater : Response
    {
        protected Response response;

        public void SetComponent(Response resp)
        {
            this.response = resp;
        }

        public override void Operation()
        {
            if (response != null)
            {
                response.Operation();
            }
        }
    }
}