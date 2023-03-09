using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class PrimaryOrder : IComparable<PrimaryOrder>
    {
        public PrimaryOrder()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid OrderId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Note { get; set; }
        public double Total { get; set; }
        public int Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int CompareTo(PrimaryOrder other)
        {
            return this.OrderDate.CompareTo(other.OrderDate)*(-1);
        }
    }
}
