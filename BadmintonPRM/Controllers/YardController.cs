using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

namespace BadmintonPRM.Controllers
{
    [Route("api/v1/yards")]
    [ApiController]
    public class YardController(IServiceProvider serviceProvider) : ControllerBase
    {
        private readonly YardService _yardService = serviceProvider.GetRequiredService<YardService>();

        [HttpGet]
        public IActionResult GetAllYards([FromQuery] int pageNumber = 1)
        {
            var yards = _yardService.GetAll(pageNumber);
            return Ok(BaseResponse.OkResponseDto(yards));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetYardById(int id)
        {
            var yard = await _yardService.GetById(id);
            return Ok(BaseResponse.OkResponseDto(yard));
        }

        [HttpPost]
        public IActionResult AddYard([FromBody] YardRequest request)
        {
            _yardService.Add(request);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateYard(int id, [FromBody] YardRequest request)
        {
            await _yardService.Update(id, request);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYard(int id)
        {
            await _yardService.Delete(id);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }
    }
}
