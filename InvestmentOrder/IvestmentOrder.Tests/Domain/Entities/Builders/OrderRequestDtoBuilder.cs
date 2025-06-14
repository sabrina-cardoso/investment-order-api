using InvestmentOrder.Domain.Dtos.Order;

public class OrderRequestDtoBuilder
{
    private int _investorId = 1;
    private string _asset = "PETR4";
    private int _amount = 10;
    private decimal _price = 30.5m;

    public OrderRequestDtoBuilder WithInvestorId(int id)
    {
        _investorId = id;
        return this;
    }

    public OrderRequestDtoBuilder WithAsset(string asset)
    {
        _asset = asset;
        return this;
    }

    public OrderRequestDtoBuilder WithAmount(int amount)
    {
        _amount = amount;
        return this;
    }

    public OrderRequestDtoBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public OrderRequestDto Build()
    {
        return OrderRequestDto.Create(_investorId, _asset, _amount, _price);
    }
}
