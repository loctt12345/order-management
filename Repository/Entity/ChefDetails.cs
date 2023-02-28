using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
   
        public partial class ChefDetails
        {
            public Guid OrderDetailsId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public DateTime OrderDate { get; set; }
            public string Note { get; set; }
           // public bool Status { get; set; }

        }
    
}
