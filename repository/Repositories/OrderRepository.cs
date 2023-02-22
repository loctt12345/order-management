using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories
{
    public class OrderRepository : RepositoryBase<PrimaryOrder>
    {
        public OrderRepository() 
        {
            
        }

        public IQueryable<PrimaryOrder> GetAll()
        {
            return _dbSet.Where(order => order.Status != 0);
        }

    }
}
