using Amazon.Suporte.Constants;
using Amazon.Suporte.Model;
using Confluent.Kafka;
using Newtonsoft.Json;
using System;

namespace Amazon.Suporte.Services
{
    public class ProducerService : IProducerService
    {
        private readonly ProducerConfig kafkaConfig;
        public ProducerService()
        {
            kafkaConfig = new ProducerConfig 
            {
                BootstrapServers = Environment
                                  .GetEnvironmentVariable(EnvironmentVariable.KafkaAddress)
                                   ?? "kafka:29092"
            };        
        }

        public QueueViewModel SendMessage(Problem problem)
        {
            var queueViewModel = new QueueViewModel();
            queueViewModel.Success = false;
            using var producer = new ProducerBuilder<Null, string>(kafkaConfig).Build();
            {
                try
                {
                    problem.CreateIdentificator();
                    string problemSerialized = JsonConvert.SerializeObject(problem);                    
                    var sendResult = producer.ProduceAsync(
                        Environment
                        .GetEnvironmentVariable(EnvironmentVariable.KafkaTopic)
                        ?? "test-topic",
                        new Message<Null, string>
                        {
                            Value = problemSerialized
                        })
                        .GetAwaiter()
                        .GetResult();
                    queueViewModel.Success = true;
                    queueViewModel.Message = $@"Your problem will be added soon, please consult by this number {problem.ProblemIdentificator}";
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
