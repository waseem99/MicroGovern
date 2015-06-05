﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Request_mng
{
    public class CommunityRequestCreator: RequestCreator
    {
        public  override Request CreateRequest()
        {
            return new CommunityRequest();
        }
    }
}