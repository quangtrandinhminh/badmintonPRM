using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

namespace BadmintonPRM.Controllers
{
    [Route("api/v1/slots")]
    [ApiController]
    public class SlotController(IServiceProvider serviceProvider) : ControllerBase
    {
        private readonly SlotService _slotService = serviceProvider.GetRequiredService<SlotService>();

        [HttpGet]
        public IActionResult GetAllSlots([FromQuery] int? yardId, DateOnly? bookingDate)
        {
            var slots = _slotService.GetAll(yardId, bookingDate);
            return Ok(BaseResponse.OkResponseDto(slots));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlotById(int id)
        {
            var slot = await _slotService.GetById(id);
            return Ok(BaseResponse.OkResponseDto(slot));
        }

        [HttpPost]
        public IActionResult AddSlot([FromBody] SlotRequest request)
        {
            _slotService.Add(request);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot(int id, [FromBody] SlotRequest request)
        {
            await _slotService.Update(id, request);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlot(int id)
        {
            await _slotService.Delete(id);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }
    }
}
