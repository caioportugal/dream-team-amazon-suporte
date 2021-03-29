using Amazon.Suporte.Model;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Suporte.Services
{
    public class ConsumerService : BackgroundService
    {
        private IProblemService _problemService;
        public ConsumerService(IProblemService problemService)
        {
            _problemService = problemService;
        }

        private async Task StartConsumer(CancellationToken stoppingToken)
        {
            string kafkaAddress = "kafka:29092";
            string topicKafka = "test-topic";
            var kafkaConfig = new ConsumerConfig { GroupId = "test-consumer-group", BootstrapServers = kafkaAddress };

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var consumer = new ConsumerBuilder<Null, string>(kafkaConfig).Build())
                {
                    consumer.Subscribe(topicKafka);
                    var consumeResult = consumer.Consume().Value;
                    if (consumeResult != null)
                    {
                        var problem = Newtonsoft.Json.JsonConvert.DeserializeObject<Problem>(consumeResult);
                        _problemService.CreateProblem(problem);
                    }
                }
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.Run(() => StartConsumer(stoppingToken));
            return Task.CompletedTask;
        }
    }
}