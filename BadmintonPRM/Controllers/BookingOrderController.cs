using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

namespace BadmintonPRM.Controllers
{
    [Route("api/v1/bookingOrder")]
    [ApiController]
    public class BookingOrderController(IServiceProvider serviceProvider) : ControllerBase
    {
        private readonly BookingOrderService _bookingOrderService = serviceProvider.GetRequiredService<BookingOrderService>();

        [HttpGet]
        public IActionResult GetAllBookingOrders([FromQuery] int customerId)
        {
            var bookingOrders = _bookingOrderService.GetAll(customerId);
            return Ok(BaseResponse.OkResponseDto(bookingOrders));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingOrderById(int id)
        {
            var bookingOrder = await _bookingOrderService.GetById(id);
            return Ok(BaseResponse.OkResponseDto(bookingOrder));
        }

        [HttpPost]
        public IActionResult AddBookingOrder([FromBody] BookingOrderRequest request)
        {
            var response = _bookingOrderService.Add(request);
            return Ok(BaseResponse.OkResponseDto(response));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookingOrder(int id, [FromBody] BookingOrderRequest request)
        {
            await _bookingOrderService.Update(id, request);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingOrder(int id)
        {
            await _bookingOrderService.Delete(id);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }
    }
}
