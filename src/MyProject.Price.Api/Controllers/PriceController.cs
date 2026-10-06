using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Price.Api.Controllers
{
    [Route("api/price")]
    [ApiController]
    public class PriceController(IPriceService service) : ControllerBase
    {
        [HttpPost]
        public ActionResult<PriceResponseContract> CalculatePrice(
            [FromBody] PriceRequestContract requestContract)
        {
            try
            {
                return Ok(service.CreatePrice(requestContract));

            }
            catch (FromCountryWeightException e)
            {
                return BadRequest(
                    new ProblemDetails
                    {
                        Title = "weight exceeded",
                        Detail = e.Message
                    }
                );
            }
        }
    }
}
