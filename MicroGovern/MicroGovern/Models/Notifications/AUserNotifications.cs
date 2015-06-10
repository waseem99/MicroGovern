using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Notifications
{
    public abstract class AUserNotifications
    {
        protected AUserNotifications successor;

        public void SetSuccessor(AUserNotifications succ)
        {
            this.successor = succ;
        }

        public abstract void HandleRequest(int request);
    }
}