using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Product : IComparable<Product>
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int CompareTo(Product other)
        {
            return this.DateCreated.CompareTo(other.DateCreated)*(-1);
        }
    }
}
