using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();   
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public async Task JoinGroup(string groupName, string agentName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("JoinGroup", $"{agentName} has joined the group {groupName}");
        }

        public async Task SendMessage(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("RecieveMessage", message);
        }
    }
}
