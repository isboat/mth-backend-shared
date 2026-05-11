namespace MemeTokenHub.Shared.Dtos;

public class TokenDto
{
    public string TokenId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string Chain { get; set; } = string.Empty;
    public string ContractAddress { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateTokenDto
{
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Chain { get; set; } = string.Empty;
    public string ContractAddress { get; set; } = string.Empty;
}
