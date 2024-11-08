using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Models;
using Service.Services;

namespace BadmintonPRM.Controllers
{
    [Route("api/yardImages")]
    [ApiController]
    public class YardImageController : ControllerBase
    {
        private readonly YardImageService _yardImageService;

        public YardImageController(YardImageService yardImageService)
        {
            _yardImageService = yardImageService;
        }

        [HttpGet]
        public IActionResult GetAllYardImages([FromQuery] int? yardId)
        {
            var yardImages = _yardImageService.GetAll(yardId);
            return Ok(BaseResponse.OkResponseDto(yardImages));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetYardImageById(int id)
        {
            var yardImage = await _yardImageService.GetById(id);
            return Ok(BaseResponse.OkResponseDto(yardImage));
        }

        [HttpPost]
        public IActionResult AddYardImage([FromBody] YardImageRequest request)
        {
            _yardImageService.Add(request);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateYardImage(int id, [FromBody] YardImageRequest request)
        {
            await _yardImageService.Update(id, request);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYardImage(int id)
        {
            await _yardImageService.Delete(id);
            return Ok(BaseResponse.OkResponseDto("Success"));
        }
    }
}
