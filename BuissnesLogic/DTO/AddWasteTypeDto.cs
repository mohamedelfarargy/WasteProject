﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.DTO
{
    public class AddWasteTypeDto
    {
        public string? WasteName { get; set; }



        public string? Description { get; set; }

       
        public decimal Price { get; set; }
    }
}
