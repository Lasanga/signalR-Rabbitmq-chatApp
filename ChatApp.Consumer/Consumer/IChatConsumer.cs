using ChatApp.Domain.Models;

namespace ChatApp.Consumer
{
    public interface IChatConsumer
    {
        void ConsumeChat(Team team);
    }
}
