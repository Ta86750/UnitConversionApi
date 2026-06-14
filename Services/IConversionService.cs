using UnitConversionApi.Models;

namespace UnitConversionApi.Services
{
    public interface IConversionService
    {
        ConversionResponse Convert(string category, string fromUnit, string toUnit, double value);
    }
}