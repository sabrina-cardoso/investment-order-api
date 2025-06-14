using InvestmentOrder.Application.Services;
using InvestmentOrder.Domain.Ports.In;
using InvestmentOrder.Domain.Ports.Out;
using InvestmentOrder.Infrastructure.Adapters.Kafka;
using InvestmentOrder.Infrastructure.Health;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInvestmentOrderProducer, KafkaInvestmentOrderProducer>();
builder.Services.AddScoped<ICreateInvestmentOrderUseCase, OrderService>();

builder.Services.AddHealthChecks()
    .AddCheck("kafka", new KafkaHealthCheck("localhost:9092"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
