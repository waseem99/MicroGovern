using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Notifications
{
    public class MobileNotifications: AUserNotifications
    {
        public override void HandleRequest(int request)
    {
        successor.HandleRequest(request);
    }
}
}