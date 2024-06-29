using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using YourNamespace.Clients;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class paymentController : ControllerBase
    {
 
        private readonly PaypalClient _paypalClient;

        public paymentController(PaypalClient paypalClient)
        {
            _paypalClient = paypalClient;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var response = await _paypalClient.CreateOrder(createOrderDto.Value, createOrderDto.Currency, createOrderDto.Reference);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("capture-order")]
        public async Task<IActionResult> CaptureOrder([FromBody] CaptureOrderDto captureOrderDto)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(captureOrderDto.OrderId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }

    public class CreateOrderDto
    {
        public string Value { get; set; }
        public string Currency { get; set; }
        public string Reference { get; set; }
    }

    public class CaptureOrderDto
    {
        public string OrderId { get; set; }
    }







}
