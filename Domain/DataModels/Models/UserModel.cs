﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataModels.Models
{
    public class UserModel
    {
        public long UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? OldPassword { get; set; }
    }
}
