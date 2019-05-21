using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace GKICMP
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.sendMessage(name, message);
        }
    }
    public class RoomHub : Hub
    {
        public void AddToRoom(string  roomId)
        {
            this.Groups.Add(Context.ConnectionId, roomId.ToString());
        }

        public void Send(ChatMessage message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<RoomHub>();
            hubContext.Clients.Group(message.RoomId.ToString()).sendMessage(message);
        }
    }

    public class ChatMessage
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}