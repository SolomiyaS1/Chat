using System;
using System.Collections.Generic;
using System.Linq;
using ChatSignalR.Models;
using Microsoft.AspNet.SignalR;

namespace ChatSignalR.Hubs
{
    public class ChatHub : Hub
    {
        IChatRepository ChatRepo = new ChatRepository();
        static List<User> UsersOnline = new List<User>();   
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            User Current = ChatRepo.GetbyName(userName);
            Current.ConnectionId = id;
            if (UsersOnline.All(x => x.ConnectionId != id))
            {
                UsersOnline.Add(Current);
                Clients.Caller.onConnected(id, userName, UsersOnline);
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }
        public void Send(string name, string message)
        {
            Message mes = new Message
            {
                UserId = ChatRepo.GetbyName(name).Id,
                Text = message,
                Time = DateTime.Now
            };
            ChatRepo.AddMessage(mes);
            Clients.All.addMessage(name, message, mes.Time.ToString("MM.dd  HH:mm:ss"));
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = UsersOnline.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                UsersOnline.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}