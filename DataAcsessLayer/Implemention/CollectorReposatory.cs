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
    public class CollectorReposatory : IRepository<Collector>
    {
        private readonly ApplactionDbcontext _context;

        public CollectorReposatory(ApplactionDbcontext context)
        {
            _context = context;
        }
        public async Task Add(Collector entity)
        {
            await _context.Set<Collector>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var collector = await _context.Collectors.FindAsync(id);
            if (collector != null)
            {
                _context.Collectors.Remove(collector);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Collector>> GetAll()
       => await _context.Set<Collector>().ToListAsync();

        public async Task<Collector> GetById(int id)
        {
            var Colectors = await _context.Collectors.FindAsync(id);
            if (Colectors == null) return null;

            return Colectors;
        }

        public async Task Update(Collector entity)
        {
            _context.Collectors.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
