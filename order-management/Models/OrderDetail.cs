﻿using System;
using System.Collections.Generic;

#nullable disable

namespace order_management.Models
{
    public partial class OrderDetail
    {
        public Guid OrderDetailsId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual PrimaryOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
