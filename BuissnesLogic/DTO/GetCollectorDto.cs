using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.DTO
{
    public class GetCollectorDto
    {
        public int Id { get; set; }


        public string? Name { get; set; }

        public string? ContactInfo { get; set; }

        public string? ServiceArea { get; set; }
    }
}
