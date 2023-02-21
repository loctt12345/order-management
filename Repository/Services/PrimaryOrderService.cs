using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IPrimaryOrderService
    {
        public void Create(PrimaryOrder PrimaryOrder);
        public void Update(PrimaryOrder PrimaryOrder);
        public void Delete(PrimaryOrder PrimaryOrder);
        public List<PrimaryOrder> GetAll();
    }
    public class PrimaryOrderService : IPrimaryOrderService
    {
        private readonly RepositoryBase<PrimaryOrder> _emloyeeService = new RepositoryBase<PrimaryOrder>();
        public PrimaryOrderService() { }

        public PrimaryOrderService(RepositoryBase<PrimaryOrder> emloyeeService)
        {
            _emloyeeService = emloyeeService;
        }

        public void Create(PrimaryOrder PrimaryOrder)
        {
            _emloyeeService.Create(PrimaryOrder);
        }

        public void Delete(PrimaryOrder PrimaryOrder)
        {
            _emloyeeService.Delete(PrimaryOrder);
        }

        public List<PrimaryOrder> GetAll()
        {
            return _emloyeeService.GetAll().ToList();
        }

        public void Update(PrimaryOrder PrimaryOrder)
        {
            _emloyeeService.Update(PrimaryOrder);
        }
    }

}
