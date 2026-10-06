using System.ComponentModel.DataAnnotations;

public class PriceRequestContract
{
    [Required]
    public double WidthCm { get; set; }
    [Required]
    public double LengthCm { get; set; }
    [Required]
    public double HeightCm { get; set; }
    [Required]
    public double WeightKg { get; set; }
    [Required]
    public CountryEnum? FromCountry { get; set; } //todo test zonder ? moet wss wel erbij
    [Required]
    public CountryEnum? ToCountry { get; set; }
}

public enum CountryEnum
{
    BE, NL, LU, FR
}