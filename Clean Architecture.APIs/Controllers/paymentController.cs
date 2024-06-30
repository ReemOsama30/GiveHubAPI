using Clean_Architecture.Application.DTOs.client;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Clients;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaypalClient _paypalClient;

        public PaymentController(PaypalClient paypalClient)
        {
            _paypalClient = paypalClient;
        }

        [HttpPost("create-donation")]
        public IActionResult CreateDonation([FromBody] DonationOrderRequestDto donationDto)
        {
            // Validate donationDto and process the donation order creation

            // Example validation:
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Example of processing the donation order creation
            var donationAmount = donationDto.Amount;
            var currency = donationDto.Currency;
            var paymentMethod = donationDto.PaymentMethod;
            var paypalOrderId = donationDto.PaypalOrderId;

            try
            {
                // Perform actions to create the donation order
                // Assuming creation logic here...

                // Simulate successful creation with a generated PayPal Order ID
                var createdOrderId = Guid.NewGuid().ToString(); // Replace with actual order ID generation logic

                // Return the created order ID in the response
                return Ok(new { message = "Donation order created successfully", orderId = createdOrderId });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Failed to create donation order: {e.Message}" });
            }
        }

        [HttpPost("capture-order")]

        public async Task<IActionResult> CaptureOrder([FromBody] CaptureOrderDto captureOrderDto)
        {
            try
            {
                // Call PayPal client to capture the order
                var response = await _paypalClient.CaptureOrder(captureOrderDto.OrderId);

                // Handle capture response as needed
                if (response != null)
                {
                    // Example: Log the response to inspect its structure
                    Console.WriteLine($"CaptureOrder response: {response}");

                    // Return the response as is for debugging purposes
                    return Ok(response);
                }
                else
                {
                    return BadRequest(new { message = "Failed to capture order" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }

}


