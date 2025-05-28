using Confluent.Kafka;
using InvestmentOrder.Domain.Entities;
using InvestmentOrder.Domain.Ports.Out;
using System.Text.Json;

namespace InvestmentOrder.Infrastructure.Adapters.Kafka
{
    public class KafkaInvestmentOrderProducer : IInvestmentOrderProducer
    {
        private readonly IProducer<Null, string> _producer;
        private const string Topic = "investment-orders";

        public KafkaInvestmentOrderProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task PublishAsync(Order order)
        {
            var json = JsonSerializer.Serialize(order);
            await _producer.ProduceAsync(Topic, new Message<Null, string> { Value = json });
        }
    }
}
