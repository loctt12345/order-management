using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IProductServices
    {
        public void Create(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public List<Product> GetAll();

    }

    public class ProductService : IProductServices
    {
        private RepositoryBase<Product> _productRepo = new RepositoryBase<Product>();

        public void Create(Product product)
        {
            _productRepo.Create(product);
        }
        public void Update(Product product)
        {
            _productRepo.Update(product);
        }

        public List<Product> GetAll()
        {
            return _productRepo.GetAll().ToList();
        }

        public void Delete(Product product)
        {
            _productRepo.Delete(product);
        }

        public List<Product> Search(string keyword)
        {
            Guid productId;
            bool isGuid = Guid.TryParse(keyword, out productId);

            return _productRepo.GetAll()
                .Where(p => isGuid && p.ProductId.Equals(productId)
                            || !isGuid && (p.ProductName.Contains(keyword)
                                           || p.Price.ToString().Contains(keyword)))
                .ToList();
        }

    }
}
