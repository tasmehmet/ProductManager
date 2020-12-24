﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Dto
{
    public class ProductImagesDto
    {
        public int Id { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImageSubText { get; set; }
        public int ProductId { get; set; }
    }
}
