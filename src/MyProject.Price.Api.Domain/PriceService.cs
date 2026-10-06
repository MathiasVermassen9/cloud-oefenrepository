
public interface IPriceService
{
    PriceResponseContract CreatePrice(PriceRequestContract package);

}

public class PriceService : IPriceService
{

    public PriceResponseContract CreatePrice(PriceRequestContract package)
    {
        //        throw new Exception("KABOOOM");

        if (package.FromCountry == CountryEnum.NL && package.WeightKg > 10)
            throw new FromCountryWeightException($"Package weight may not exceed 10kg for fromCountry NL. Value provided was {package.WeightKg}");

        return new PriceResponseContract
        {
            Price = Calc(package),
            ValidUntil = DateTime.UtcNow.AddHours(48)
        };
    }

    private static decimal Calc(PriceRequestContract package)
    {
        var volumeCm3 = package.HeightCm * package.LengthCm * package.WidthCm;

        var basePrice = 2.5 + volumeCm3 * 0.0001 + package.WeightKg * 1.15;
        var borderSurcharge = package.FromCountry == package.ToCountry ? 0.0 : 3.0;

        var totalPrice = (decimal)(basePrice + borderSurcharge);
        var totalPriceRounded = Math.Round(totalPrice, 1);

        return totalPriceRounded;
    }

}