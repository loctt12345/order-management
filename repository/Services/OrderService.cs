using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Services
{
    public interface IOrderService
    {
        public void Create(PrimaryOrder order);
        public void Update(PrimaryOrder order);
        public void Delete(PrimaryOrder order); 
        public List<PrimaryOrder> GetAll();
    }

    public class OrderService : IOrderService
    {
        private RepositoryBase<PrimaryOrder> _primaryOrder = new RepositoryBase<PrimaryOrder>();

        public OrderService() { }
        public void Create(PrimaryOrder order)
        {
            this._primaryOrder.Create(order);
        }
        public void Update(PrimaryOrder order)
        {
            this._primaryOrder.Update(order);
        }
        public void Delete(PrimaryOrder order)
        {
            this._primaryOrder.Delete(order);
        }
        public List<PrimaryOrder> GetAll()
        {
            return this._primaryOrder.GetAll().ToList();
        }
    }
}
