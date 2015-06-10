using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Responses_mng
{
    public class VerifiedUserResponseDecorator : ResponseADecorater
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = " VerifiedUserr State";
        }
    }
}