using Microsoft.AspNetCore.Mvc;

namespace restwithaspnet.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult GetSub(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mul/{firstNumber}/{secondNumber}")]
    public IActionResult GetMul(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult GetDiv(string firstNumber, string secondNumber)
    {
        if ((IsNumeric(firstNumber) && IsNumeric(secondNumber)) && ConvertToDecimal(firstNumber)!= 0 && ConvertToDecimal(secondNumber)!=0)
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("avg/{firstNumber}/{secondNumber}")]
    public IActionResult GetAvg(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            var avg = sum / 2;
            return Ok(avg.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("sqrt/{firstNumber}/")]
    public IActionResult GetSqrt(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var sum = Math.Sqrt(ConvertToDouble(firstNumber)); 
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }


    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }

        return 0;
    }

    private double ConvertToDouble(string strNumber)
    {
        double doubleValue;
        if (double.TryParse(strNumber, out doubleValue))
        {
            return doubleValue;
        }

        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(
            strNumber, 
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);

        return isNumber;
    }
}
