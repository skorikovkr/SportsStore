using System;
using System.Collections.Generic;

namespace SportsStore.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Category { get; set; }
    }
}
