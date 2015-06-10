﻿using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using ChatApplication.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ChatApplication
{
    public class ChatHub : Hub
    {
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });
                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);
                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }

        }

        public void SendMessageToAll(string userName, string message)
        {
            // store last 100 messages in cache
            AddMessageinCache(userName, message);

            // Broad cast message
            Clients.All.messageReceived(userName, message);
        }

        public void SendPrivateMessage(string toUserId, string message)
        {
            string fromUserId = Context.ConnectionId;
            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);
            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }

        }

        private void AddMessageinCache(string userName, string message)
        {
            CurrentMessage.Add(new MessageDetail { UserName = userName, Message = message });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);
            }
            return base.OnDisconnected(stopCalled);
        }


    }
}