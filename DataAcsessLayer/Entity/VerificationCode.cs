﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Entity
{
    public class VerificationCode
    {
        public int Id { get; set; }

        
        public int UserId { get; set; }
        public User? User { get; set; }

      
        public string? Code { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

    }
}
