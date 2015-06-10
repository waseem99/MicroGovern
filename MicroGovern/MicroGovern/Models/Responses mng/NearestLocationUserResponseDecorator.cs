using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Responses_mng
{
    public class NearestLocationUserResponseDecorator : ResponseADecorater
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "NearestLocationUser State";
        }
    }
}