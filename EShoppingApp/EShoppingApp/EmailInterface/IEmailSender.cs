using EShoppingApp.EmailModels;

namespace EShoppingApp.EmailInterface
{
    public interface IEmailSender
    {
        void SendEmail(Message email);
    }
}
