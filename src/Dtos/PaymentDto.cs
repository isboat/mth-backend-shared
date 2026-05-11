namespace MemeTokenHub.Shared.Dtos;

public class PaymentDto
{
    public string PaymentId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string TokenId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateCheckoutDto
{
    public string TokenId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
