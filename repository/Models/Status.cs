using System;
using System.Collections.Generic;

#nullable disable

namespace repository.Models
{
    public partial class Status
    {
        public Status()
        {
            PrimaryOrders = new HashSet<PrimaryOrder>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PrimaryOrder> PrimaryOrders { get; set; }
    }
}
