using BuissnesLogic.DTO;
using BuissnesLogic.ServiceIntrface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntaionLayer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RecyclingRequestController : ControllerBase
    {
       private readonly IRecyclingRequestService _recyclingRequestService;

        public RecyclingRequestController(IRecyclingRequestService recyclingRequestService)
        {
            _recyclingRequestService = recyclingRequestService;
        }

        // إضافة طلب تدوير جديد
        [HttpPost]
        public async Task<IActionResult> AddRecyclingRequest([FromBody] 
        AddRequestDto requestDto)
        {
            try
            {
                await _recyclingRequestService.AddRecyclingRequestAsync(requestDto);
                return Ok("Recycling request added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // الحصول على جميع طلبات التدوير
        [HttpGet]
        public async Task<IActionResult> GetAllRecyclingRequests()
        {
            try
            {
                var requests = await _recyclingRequestService.GetAllRecyclingRequestsAsync();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("lastActivity")]
          public async Task<IActionResult> GetAllActivity()
          {
              try
              {
                  var requests = await _recyclingRequestService.GetAllActivity();
                  return Ok(requests);
              }
              catch (Exception ex)
              {
                  return BadRequest(ex.Message);
              }
          }

          
        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
          
            var totalQuantity = await _recyclingRequestService.GetTotalQuantityAsync();
         

            return Ok(new
            {
              
                TotalQuantity = totalQuantity 
             
            });
        }
    }
}
