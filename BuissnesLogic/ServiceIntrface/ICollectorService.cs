using BuissnesLogic.DTO;
using DataAcsessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.ServiceIntrface
{
    public interface ICollectorService
    {
        Task AddCollectorAsync(AddCollectorDto user);
        Task<IEnumerable<GetCollectorDto>> GetAllCollectorAsync();
    }
}
