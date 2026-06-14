using UnitConversionApi.Models;

namespace UnitConversionApi.Services
{
    public class ConversionService : IConversionService
    {
        public ConversionResponse Convert(string category, string fromUnit, string toUnit, double value)
        {
            category = category.ToLower();
            fromUnit = fromUnit.ToLower();
            toUnit = toUnit.ToLower();

            double result = category switch
            {
                "length" => ConvertLength(fromUnit, toUnit, value),
                "weight" or "mass" => ConvertWeight(fromUnit, toUnit, value),
                "temperature" => ConvertTemperature(fromUnit, toUnit, value),
                _ => throw new ArgumentException("Invalid category. Supported categories are length, weight/mass, and temperature.")
            };

            return new ConversionResponse
            {
                Category = category,
                FromUnit = fromUnit,
                ToUnit = toUnit,
                InputValue = value,
                ConvertedValue = Math.Round(result, 4)
            };
        }

        private double ConvertLength(string fromUnit, string toUnit, double value)
        {
            var factors = new Dictionary<string, double>
            {
                { "meter", 1 },
                { "kilometer", 1000 },
                { "centimeter", 0.01 },
                { "feet", 0.3048 },
                { "inch", 0.0254 }
            };

            if (!factors.ContainsKey(fromUnit) || !factors.ContainsKey(toUnit))
                throw new ArgumentException("Invalid length unit.");

            double valueInMeters = value * factors[fromUnit];
            return valueInMeters / factors[toUnit];
        }

        private double ConvertWeight(string fromUnit, string toUnit, double value)
        {
            var factors = new Dictionary<string, double>
            {
                { "kilogram", 1 },
                { "gram", 0.001 },
                { "pound", 0.45359237 }
            };

            if (!factors.ContainsKey(fromUnit) || !factors.ContainsKey(toUnit))
                throw new ArgumentException("Invalid weight/mass unit.");

            double valueInKilograms = value * factors[fromUnit];
            return valueInKilograms / factors[toUnit];
        }

        private double ConvertTemperature(string fromUnit, string toUnit, double value)
        {
            double celsius = fromUnit switch
            {
                "celsius" => value,
                "fahrenheit" => (value - 32) * 5 / 9,
                "kelvin" => value - 273.15,
                _ => throw new ArgumentException("Invalid temperature unit.")
            };

            return toUnit switch
            {
                "celsius" => celsius,
                "fahrenheit" => (celsius * 9 / 5) + 32,
                "kelvin" => celsius + 273.15,
                _ => throw new ArgumentException("Invalid temperature unit.")
            };
        }
    }
}