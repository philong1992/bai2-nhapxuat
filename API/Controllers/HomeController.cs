using API._Services.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _service;
        public HomeController(IHomeService service) {
            _service = service;
        }

        [HttpGet("getData")]
        public async Task<IActionResult> GetData(string searchStr) {
            var data = await _service.GetData(searchStr);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(NhapXuat model) {
            var data = await _service.Add(model);
            return Ok(data);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(NhapXuat model) {
            var result = await _service.Delete(model);
            return Ok(result);
        }

        [HttpGet("deleteSP")]
        public async Task<IActionResult> DeleteSP(string sophieu) {
            var result = await _service.DeleteSP(sophieu);
            return Ok(result);
        }
    }
}