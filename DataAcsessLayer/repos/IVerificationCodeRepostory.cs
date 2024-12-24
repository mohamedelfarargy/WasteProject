using DataAcsessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.repos
{
    public interface IVerificationCodeRepostory
    {
        Task AddAsync(VerificationCode verificationCode);
        Task<VerificationCode> GetByUserIdAsync(int userId);
        Task DeleteAsync(VerificationCode verificationCode);

    }
}
