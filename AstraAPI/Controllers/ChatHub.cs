using Astra.BLL.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace AstraAPI.Controllers
{
    public sealed class ChatHub : Hub
    {
        private static readonly Dictionary<string, string> userConnections = new Dictionary<string, string>();
        private readonly IUserBLLService _userService;

        public ChatHub(IUserBLLService userService)
        {
            _userService = userService;
        }
        public override async Task OnConnectedAsync()
        {
            string userId = Context.GetHttpContext().Request.Query["userId"];
            string connectionId = Context.ConnectionId;

            if (!string.IsNullOrEmpty(userId))
            {
                userConnections[userId] = connectionId;
            }
            await base.OnConnectedAsync();
        }

        public async Task SendPrivateMessage(string userId, string message)
        {
            if (userConnections.TryGetValue(userId, out string receiverConnectionId))
            {
                // Envoyer le message privé à l'utilisateur cible
                string authorMsg =  _userService.GetPseudo(Context.GetHttpContext().Request.Query["userId"]);
                await Clients.Client(receiverConnectionId).SendAsync("ReceivePrivateMessage", authorMsg, message);
            }
            if (userConnections.TryGetValue(Context.GetHttpContext().Request.Query["userId"], out string senderConnectionId))
            {
                //afficher également pour le sender
                string authorMsg = _userService.GetPseudo(Context.GetHttpContext().Request.Query["userId"]);
                await Clients.Client(senderConnectionId).SendAsync("ReceivePrivateMessage", authorMsg, message);
            }

        }
    }
}