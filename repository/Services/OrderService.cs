using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Repositories;

namespace Repository.Services
{
    public interface IOrderService
    {
        public void Create(PrimaryOrder order);
        public void Update(PrimaryOrder order);
        public void Delete(PrimaryOrder order); 
        public List<PrimaryOrder> GetAll();

        public PrimaryOrder GetById(Guid id);

     
    }

    public class OrderService : IOrderService
    {
        private OrderRepository _orderRepository = new OrderRepository();

        public OrderService() { }
        public void Create(PrimaryOrder order)
        {
            this._orderRepository.Create(order);
        }
        public void Update(PrimaryOrder order)
        {
            this._orderRepository.Update(order);
        }
        public void Delete(PrimaryOrder order)
        {
            this._orderRepository.Delete(order);
        }
        public List<PrimaryOrder> GetAll()
        {
            return this._orderRepository.GetAll().ToList();
        }

     

        public PrimaryOrder GetById(Guid id)
        {
            return this._orderRepository.GetAll()
                .Where(order => order.OrderId.Equals(id)).FirstOrDefault();
        }
    }
}
