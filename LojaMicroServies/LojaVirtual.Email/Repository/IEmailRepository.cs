using LojaVirtual.Email.Messages;

namespace LojaVirtual.Email.Repository
{
    public interface IEmailRepository
    {

        Task LogEmail(UpdatePaymentResultMessage message);

    }
}
