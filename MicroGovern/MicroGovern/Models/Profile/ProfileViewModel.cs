using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Profile
{
    public class ProfileViewModel
    {

    }

    public class UserProfileModel
    {
        public string userID;
        public float ratings;
        public string profilePhotoURL;
        //MY SERVICES LIST
        public float ratePerHr;
        public string ServicesCompleted; //OR HISTORY LIST
        public string CurrentActiveServices;
    }
}