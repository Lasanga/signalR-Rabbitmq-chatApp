namespace ChatApp.RabbitMq.Producer
{
    public interface IChatSender
    {
        void SendChatId(string connectionId);
    }
}
