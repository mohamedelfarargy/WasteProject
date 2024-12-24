using BuissnesLogic.DTO;
using DataAcsessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.ServiceIntrface
{
    public interface IRecyclingRequestService
    {
        Task AddRecyclingRequestAsync(AddRequestDto requestDto);
        Task<IEnumerable<GetRequestDto>> GetAllRecyclingRequestsAsync();
        Task<IEnumerable<LastActivityDTO>> GetAllActivity();
        Task<decimal> GetTotalQuantityAsync();
    }
}
    
