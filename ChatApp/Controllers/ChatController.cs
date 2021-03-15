using ChatApp.Core.Command;
using ChatApp.Domain.Models;
using ChatApp.Hubs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IMediator mediator, IHubContext<ChatHub> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task InitChat([FromBody]string connectionId)
        {
            await _hubContext.Groups.AddToGroupAsync(connectionId, connectionId);
            await _mediator.Send(new CreateChatCommand
            {
                Chat = new Chat() { ConnectionId = connectionId }
            });
        }
    }
}
