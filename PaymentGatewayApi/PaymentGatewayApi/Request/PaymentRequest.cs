using System.ComponentModel.DataAnnotations;

namespace PaymentGatewayApi.Request;

public class PaymentRequest
{
    [Required]
    [CreditCard]
    public string CardNumber { get; set; }

    [Required]
    [RegularExpression("^(0[1-9]|1[0-2])\\/?([0-9]{2})$")]
    public string ExpiryMonthYear { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    [StringLength(3)]
    public string Currency { get; set; }

    [Required]
    [Range(100, 999)]
    public int Cvv { get; set; }
}