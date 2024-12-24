using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.ServiceIntrface
{
    public interface IVerificationCodeService
    {
        Task GenerateCodeAsync(int userId); // توليد رمز
        Task<bool> ValidateCodeAsync(int userId, string code); // تحقق من الرمز
        Task DeleteExpiredCodesAsync(); // حذف الرموز المنتهية الصلاحية
    }
}
