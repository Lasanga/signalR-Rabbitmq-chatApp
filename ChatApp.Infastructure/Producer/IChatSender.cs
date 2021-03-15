namespace ChatApp.Infastructure.Producer
{
    public interface IChatSender
    {
        void SendChatId(string connectionId);
    }
}
