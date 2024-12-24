using BuissnesLogic.DTO;
using DataAcsessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.ServiceIntrface
{
    public interface IWasteTypeService
    {
        Task<IEnumerable<GetWasteTypeDto>> GetAllWasteTypesAsync(); // استرجاع الأنواع
        Task AddWasteTypeAsync(AddWasteTypeDto wasteType); // إضافة نوع
        Task DeleteWasteTypeAsync(int id); //
        Task UpdateWasteAsync(GetWasteTypeDto user);
    }
}
