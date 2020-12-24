﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
