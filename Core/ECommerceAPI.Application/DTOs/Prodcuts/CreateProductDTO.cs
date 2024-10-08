﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs.Prodcuts
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ModelNo { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public int Rating { get; set; } = 0;
        public int RatingCount { get; set; } = 0;
        public string? Description { get; set; }
    }
}
