using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Entity
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }


        public string? Name { get; set; }


        public string? Address { get; set; }



   
        public string? UserRole { get; set; }  // الحقل الجديد

        public ICollection<RecyclingRequest> RecyclingRequests { get; set; } = new HashSet<RecyclingRequest>();
        public ICollection<VerificationCode> VerificationCodes { get; set; } = new HashSet<VerificationCode>();
    }
}
