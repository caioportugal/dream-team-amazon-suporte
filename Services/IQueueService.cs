using Amazon.Suporte.Model;
using System.Threading.Tasks;

namespace Amazon.Suporte.Services
{
    public interface IQueueService
    {
        QueueViewModel SendMessage(Problem problem);
        
    }
}
