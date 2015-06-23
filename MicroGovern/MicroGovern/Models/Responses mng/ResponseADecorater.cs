using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Responses_mng
{
    public class ResponseADecorater : Response
    {
        [Key]
        public int ID { get; set; }
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