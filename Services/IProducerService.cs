using Amazon.Suporte.Model;

namespace Amazon.Suporte.Services
{
    public interface IProducerService
    {
        QueueViewModel SendMessage(Problem problem);        
    }
}
