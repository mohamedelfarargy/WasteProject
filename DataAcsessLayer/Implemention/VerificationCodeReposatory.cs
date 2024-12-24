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
    public class VerificationCodeReposatory : IVerificationCodeRepostory
    {
        private readonly ApplactionDbcontext _context;

        public VerificationCodeReposatory(ApplactionDbcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(VerificationCode verificationCode)
        {
            await _context.Set<VerificationCode>().AddAsync(verificationCode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(VerificationCode verificationCode)
        {
            _context.VerificationCodes.Remove(verificationCode);
            await _context.SaveChangesAsync();
        }

        public async Task<VerificationCode> GetByUserIdAsync(int userId)
        {
            return await _context.VerificationCodes.FirstOrDefaultAsync(vc => vc.UserId == userId);
        }
    }
}
