using InvestmentOrder.Domain.Entities;
using Xunit;

namespace IvestmentOrder.Tests.Domain.Entities;

public class OrderTests
{
    [Fact]
    public void Create_WithValidBuilderDto_ShouldReturnValidOrder()
    {
        // Arrange
        var dto = new OrderRequestDtoBuilder()
                    .WithAsset("ITUB4")
                    .WithAmount(50)
                    .WithPrice(12.75m)
                    .Build();

        // Act
        var order = Order.Create(dto);

        // Assert
        Assert.NotNull(order);
        Assert.Equal("ITUB4", order.Asset);
        Assert.Equal(50, order.Amount);
        Assert.Equal(12.75m, order.Price);
    }

    [Fact]
    public void Create_InvalidInvestorId_ShouldThrowArgumentException()
    {
        var dto = new OrderRequestDtoBuilder()
                    .WithInvestorId(0)
                    .Build();

        var exception = Assert.Throws<ArgumentException>(() => Order.Create(dto));
        Assert.Contains("Investor ID", exception.Message);
    }

    [Fact]
    public void Create_EmptyAsset_ShouldThrowArgumentException()
    {
        var dto = new OrderRequestDtoBuilder()
                    .WithAsset("")
                    .Build();

        var exception = Assert.Throws<ArgumentException>(() => Order.Create(dto));
        Assert.Contains("Asset", exception.Message);
    }

    [Fact]
    public void Create_NegativeAmount_ShouldThrowArgumentException()
    {
        var dto = new OrderRequestDtoBuilder()
                    .WithAmount(-5)
                    .Build();

        var exception = Assert.Throws<ArgumentException>(() => Order.Create(dto));
        Assert.Contains("Amount", exception.Message);
    }

    [Fact]
    public void Create_ZeroPrice_ShouldThrowArgumentException()
    {
        var dto = new OrderRequestDtoBuilder()
                    .WithPrice(0)
                    .Build();

        var exception = Assert.Throws<ArgumentException>(() => Order.Create(dto));
        Assert.Contains("Price", exception.Message);
    }

}

