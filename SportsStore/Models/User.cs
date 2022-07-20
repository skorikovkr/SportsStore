using System;
using System.Collections.Generic;

namespace SportsStore.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public long Age { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
