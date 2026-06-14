using Microsoft.AspNetCore.Mvc;
using UnitConversionApi.Services;

namespace UnitConversionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionsController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionsController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet("convert")]
        public IActionResult Convert(
            [FromQuery] string category,
            [FromQuery] string fromUnit,
            [FromQuery] string toUnit,
            [FromQuery] double value)
        {
            try
            {
                var result = _conversionService.Convert(category, fromUnit, toUnit, value);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}