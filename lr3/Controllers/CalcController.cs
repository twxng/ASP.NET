using Microsoft.AspNetCore.Mvc;
using lr3.Services;
using Microsoft.Extensions.Logging;

namespace lr3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcController : ControllerBase
    {
        private readonly ICalcService _calcService;
        private readonly ILogger<CalcController> _logger;

        public CalcController(ICalcService calcService, ILogger<CalcController> logger)
        {
            _calcService = calcService;
            _logger = logger;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            var result = _calcService.Add(a, b);
            _logger.LogInformation($"Add operation: {a} + {b} = {result}");
            return Ok(new { result });
		}

        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b)
        {
            var result = _calcService.Subtract(a, b);
            _logger.LogInformation($"Subtract operation: {a} - {b} = {result}");
            return Ok(new { result });
						// return Ok(new { result = _calcService.Subtract(a, b) });
        }
				

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b)
        {
            var result = _calcService.Multiply(a, b);
            _logger.LogInformation($"Multiply operation: {a} * {b} = {result}");
            return Ok(new { result });
        }

        [HttpGet("divide")]
        public IActionResult Divide(int a, int b)
        {
            try
            {
                var result = _calcService.Divide(a, b);
                _logger.LogInformation($"Divide operation: {a} / {b} = {result}");
                return Ok(new { result });
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError(ex, "Cannot divide by zero");
                return BadRequest("Cannot divide by zero");
            }
        }
    }
}