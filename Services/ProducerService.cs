using Amazon.Suporte.Model;
using Confluent.Kafka;
using System;

namespace Amazon.Suporte.Services
{
    public class ProducerService : IProducerService
    {
        private IProblemService _problemService;
        private readonly string kafkaAddress = "kafka:29092";
        private readonly string topicKafka = "test-topic";
        private readonly ProducerConfig kafkaConfig;

        public ProducerService(IProblemService problemService)
        {
            _problemService = problemService;
            kafkaConfig = new ProducerConfig { BootstrapServers = kafkaAddress };
        }
        public QueueViewModel SendMessage(Problem problem)
        {
            var queueViewModel = new QueueViewModel();
            queueViewModel.Success = false;


            using var producer = new ProducerBuilder<Null, string>(kafkaConfig).Build();
            {
                try
                {
                    string problemaObj = Newtonsoft.Json.JsonConvert.SerializeObject(problem);
                    var sendResult = producer.ProduceAsync(topicKafka, new Message<Null, string>
                    { Value = problemaObj }).GetAwaiter().GetResult();

                    queueViewModel.Success = true;
                    queueViewModel.Message = "Problem successfully added to the queue";

                }
                catch (ProduceException<Null, Problem> e)
                {
                    queueViewModel.Message = $"Delivery failed: {e.Error.Reason}";
                }
                return queueViewModel;
            }
        }
    }
}
