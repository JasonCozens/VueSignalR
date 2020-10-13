using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace VueSignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Broadcast(string name, string message)
        {
            await Clients.All.SendAsync("newMessage", name, message);
        }
    }
}
