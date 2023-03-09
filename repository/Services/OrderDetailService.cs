
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IOrderDetailService
    {
        public void Create(OrderDetail orderDetail);
        public void Update(OrderDetail orderDetail);
        public void Delete(OrderDetail orderDetail);
        public List<OrderDetail> GetAll();

        public void DeleteByOrderId(Guid orderId);

        public OrderDetail GetById(Guid id);

        public List<OrderDetail> GetByOrderId(Guid orderId);

    }

    public class OrderDetailService : IOrderDetailService
    {
        private RepositoryBase<OrderDetail> _orderDetailRepo = new RepositoryBase<OrderDetail>();

        public OrderDetailService() { }

        public void Create(OrderDetail orderDetail)
        {
            _orderDetailRepo.Create(orderDetail);
        }
        public void Update(OrderDetail orderDetail)
        {
            _orderDetailRepo.Update(orderDetail);
        }
        public void Delete(OrderDetail orderDetail)
        {
            _orderDetailRepo.Delete(orderDetail);
        }

        public List<OrderDetail> GetAll()
        {
            return this._orderDetailRepo.GetAll().ToList();
        }

        public void DeleteByOrderId(Guid orderId)
        {
            var list = this._orderDetailRepo.GetAll().Where(orderDetail => orderDetail.OrderId.Equals(orderId)).ToList();
            foreach (var item in list)
            {
                this._orderDetailRepo.Delete(item);
            }
        }

        public List<OrderDetail> GetByOrderId(Guid orderId)
        {
            return _orderDetailRepo.GetAll().Where(orderDetail => orderDetail.OrderId.Equals(orderId)).ToList();
        }

        public OrderDetail GetById(Guid id)
        {
            return GetAll().Where(orderDetail => orderDetail.OrderDetailsId.Equals(id)).FirstOrDefault();
        }
    }
}
