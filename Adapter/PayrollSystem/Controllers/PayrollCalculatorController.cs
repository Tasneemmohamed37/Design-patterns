
using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Core;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollCalculatorController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public ActionResult<decimal> Calculate(Employee employee)
        {
            var calc = new PayrollCalculator();
            return Ok(calc.Calculate(employee));
        }
    }
}
