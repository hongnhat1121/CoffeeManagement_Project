﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeManagement.DAL.Models
{
    public partial class OrderDetail
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int? Price { get; set; }
        public int Quantity { get; set; }
        public double? Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
