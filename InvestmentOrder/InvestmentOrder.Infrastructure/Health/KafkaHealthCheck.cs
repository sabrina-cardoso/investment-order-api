using Microsoft.Extensions.Diagnostics.HealthChecks;
using Confluent.Kafka;

namespace InvestmentOrder.Infrastructure.Health;

public class KafkaHealthCheck : IHealthCheck
{
    private readonly string _bootstrapServers;

    public KafkaHealthCheck(string bootstrapServers)
    {
        _bootstrapServers = bootstrapServers;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var config = new ProducerConfig { BootstrapServers = _bootstrapServers };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            producer.Flush(TimeSpan.FromMilliseconds(100)); // tentativa de conectar

            return Task.FromResult(HealthCheckResult.Healthy("Kafka está acessível."));
        }
        catch (Exception ex)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy("Kafka não está acessível.", ex));
        }
    }
}
