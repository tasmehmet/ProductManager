using ProductManagerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagerApp.Cms.Models
{
    public class RegisterViewModel
    {
        public UsersDto User { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}