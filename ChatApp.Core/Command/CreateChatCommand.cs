using ChatApp.Domain.Models;
using MediatR;

namespace ChatApp.Core.Command
{
    public class CreateChatCommand: IRequest<Chat>
    {
        public Chat Chat { get; set; }
    }
}
