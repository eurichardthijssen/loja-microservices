using LojaVirtual.MessageBus;

namespace LojaVirtual.PaymentAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}
