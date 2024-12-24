using BuissnesLogic.DTO;
using BuissnesLogic.ServiceIntrface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntaionLayer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CollectorController : ControllerBase
    {
        private readonly ICollectorService _collectorService;

        public CollectorController(ICollectorService collectorService)
        {
            _collectorService = collectorService;
        }

        // إضافة جامع جديد
        [HttpPost]
        public async Task<IActionResult> AddCollector([FromBody] AddCollectorDto collectorDto)
        {
            if (collectorDto == null)
                return BadRequest("Collector data is null.");

            try
            {
                await _collectorService.AddCollectorAsync(collectorDto);
                return Ok("Collector added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // الحصول على جميع الجامعين
        [HttpGet]
        public async Task<IActionResult> GetAllCollectors()
        {
            try
            {
                var collectors = await _collectorService.GetAllCollectorAsync();
                return Ok(collectors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
