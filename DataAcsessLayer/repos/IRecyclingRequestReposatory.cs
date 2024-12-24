using DataAcsessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.repos
{
    public interface IRecyclingRequestReposatory : IRepository<RecyclingRequest>
    {
        Task<decimal> GetTotalQuantityAsync();
        Task<IEnumerable<RecyclingRequest>> GetByUserIdAsync(int userId);
    }
}
