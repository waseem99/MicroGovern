using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApplication.Models
{
    public static class OnlineUser
    {
        public static List<UserModel> userObj = new List<UserModel>();

        public static void AddOnlineUser(string strConnectionId, string strUserName, string strUserId, string strSessionId)
        {
            UserModel user = new UserModel();
            user.connectionId = strConnectionId;
            user.userName = strUserName;
            user.userId = strUserId;
            user.newStatus = true;
            user.sessionId = strSessionId;
            userObj.Add(user);
        }

        public static void RemoveOnlineUser(string strConnectionId, string strUserName, string strUserId)
        {
            var userRemove = (UserModel)userObj.Where(item => item.connectionId == strConnectionId && item.userName == strUserName);
            userObj.Remove(userRemove);
        }
    }
}