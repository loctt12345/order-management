using System;
using System.Collections.Generic;

#nullable disable

namespace order_management.Models
{
    public partial class Employee
    {
        public Employee()
        {
            PrimaryOrders = new HashSet<PrimaryOrder>();
        }

        public Guid EmployeeId { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public bool Status { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<PrimaryOrder> PrimaryOrders { get; set; }
    }
}
