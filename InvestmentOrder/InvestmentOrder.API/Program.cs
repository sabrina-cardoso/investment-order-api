using InvestmentOrder.Application.UseCases;
using InvestmentOrder.Domain.Ports.In;
using InvestmentOrder.Domain.Ports.Out;
using InvestmentOrder.Infrastructure.Adapters.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInvestmentOrderProducer, KafkaInvestmentOrderProducer>();
builder.Services.AddScoped<ICreateInvestmentOrderUseCase, CreateInvestmentOrder>();

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

app.Run();
