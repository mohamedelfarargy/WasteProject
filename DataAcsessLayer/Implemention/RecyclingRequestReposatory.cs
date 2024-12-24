using DataAcsessLayer.Data;
using DataAcsessLayer.Entity;
using DataAcsessLayer.repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Implemention
{
    public class RecyclingRequestReposatory : IRecyclingRequestReposatory
    {
        private readonly ApplactionDbcontext _context;
        public RecyclingRequestReposatory(ApplactionDbcontext context)
        {
            _context = context;
        }
        public async Task Add(RecyclingRequest entity)
        {
            await _context.Set<RecyclingRequest>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var RecyclingRequest = await _context.RecyclingRequests.FindAsync(id);
            if (RecyclingRequest != null)
            {
                _context.RecyclingRequests.Remove(RecyclingRequest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RecyclingRequest>> GetAll()
        => await _context.Set<RecyclingRequest>().ToListAsync();

        public async Task<RecyclingRequest> GetById(int id)
        {
            var RecyclingRequest = await _context.RecyclingRequests.FindAsync(id);
            if (RecyclingRequest == null) return null;

            return RecyclingRequest;
        }

        public async Task<IEnumerable<RecyclingRequest>> GetByUserIdAsync(int userId)
        {
            return await _context.RecyclingRequests.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<decimal> GetTotalQuantityAsync()
        {
            return await _context.RecyclingRequests.SumAsync(r => r.Quantity);
        }

        public async Task Update(RecyclingRequest entity)
        {
            _context.
                RecyclingRequests.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
