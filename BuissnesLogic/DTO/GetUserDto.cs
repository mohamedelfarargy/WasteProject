using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.DTO
{
    public class GetUserDto
    {
        public int Id { get; set; } // معرف المستخدم

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? UserRole { get; set; }

        public string? Email { get; set; }
    }
}
