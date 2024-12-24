using BuissnesLogic.DTO;
using BuissnesLogic.ServiceIntrface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntaionLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WasteTypeController : ControllerBase
    {
       private readonly IWasteTypeService _wasteTypeService;

        public WasteTypeController(IWasteTypeService wasteTypeService)
        {
            _wasteTypeService = wasteTypeService;
        }

        // إضافة نوع نفايات جديد
        [HttpPost]
        public async Task<IActionResult> AddWasteType([FromBody] AddWasteTypeDto wasteType)
        {
            if (wasteType == null)
            {
                return BadRequest("Waste type cannot be null.");
            }

            await _wasteTypeService.AddWasteTypeAsync(wasteType);
            return Ok("Waste type added successfully.");
        }

        // عرض كل أنواع النفايات
        [HttpGet]
        public async Task<IActionResult> GetAllWasteTypes()
        {
            var wasteTypes = await _wasteTypeService.GetAllWasteTypesAsync();
            if (wasteTypes == null || !wasteTypes.Any())
            {
                return NotFound("No waste types found.");
            }

            return Ok(wasteTypes);
        }

        // حذف نوع نفايات
        [HttpDelete(" {id}")]
        public async Task<IActionResult> DeleteWasteType(int id)
        {
            try
            {
                await _wasteTypeService.DeleteWasteTypeAsync(id);
                return Ok("Waste type deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWasteType(int id, [FromBody] GetWasteTypeDto wasteTypeDto)
        {
            if (id != wasteTypeDto.Id)
            {
                return BadRequest("WasteType ID mismatch.");
            }

            try
            {
                await _wasteTypeService.UpdateWasteAsync(wasteTypeDto);
                return Ok("WasteType updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
