using Amazon.Suporte.Constants;
using Amazon.Suporte.Model;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Suporte.Services
{
    public class ConsumerService : IHostedService, IDisposable
    {
        private IProblemService _problemService;
        private Timer _timer;

        public ConsumerService(IProblemService problemService)
        {
            _problemService = problemService;
        }

        private void StartConsumer(object state)
        {
            var kafkaConfig = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = Environment
                                  .GetEnvironmentVariable(EnvironmentVariable.KafkaAddress) 
                                  ?? "kafka:29092"
            };
            using (var consumer = new ConsumerBuilder<Null, string>(kafkaConfig).Build())
            {
                try
                {
                    consumer.Subscribe(Environment
                                      .GetEnvironmentVariable(EnvironmentVariable.KafkaTopic) 
                                      ?? "test-topic");
                    var problemResult = consumer.Consume().Value;
                    if (problemResult != null)
                    {
                        var problem = JsonConvert.DeserializeObject<Problem>(problemResult);
                        _problemService.CreateProblem(problem);
                    }
                }
                catch (Exception e)
                {
                    //TODO: We had some problems with the library and we couldn't create a topic automatically.
                    Console.WriteLine($"Exception {e.Message}");
                }                
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(StartConsumer,
                              null,
                              TimeSpan.Zero,
                              TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}