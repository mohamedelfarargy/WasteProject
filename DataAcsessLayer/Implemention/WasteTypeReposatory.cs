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
    public class WasteTypeReposatory : IWasteTypeReposatory
    {
        private readonly ApplactionDbcontext _context;
        public WasteTypeReposatory(ApplactionDbcontext context)
        {
            _context = context;
        }
        public async Task Add(WasteType entity)
        {
            await _context.Set<WasteType>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var WasteType = await _context.WasteTypes.FindAsync(id);
            if (WasteType != null)
            {
                _context.WasteTypes.Remove(WasteType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WasteType>> GetAll()
       => await _context.Set<WasteType>().ToListAsync();

        public async Task<WasteType> GetById(int id)
        {
            var WasteType = await _context.WasteTypes.FindAsync(id);
            if (WasteType == null) return null;

            return WasteType;
        }

        public async Task Update(WasteType entity)
        {
            _context.WasteTypes.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
