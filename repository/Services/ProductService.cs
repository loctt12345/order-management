using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IProductService
    {
        public void Create(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public List<Product> GetAll();
        public Product GetById(Guid id);
    }

    public class ProductService : IProductService
    {
        private RepositoryBase<Product> _productRepo = new RepositoryBase<Product>();

        public ProductService() { }

        public void Create(Product product)
        {
            this._productRepo.Create(product);
        }

        public void Update(Product product)
        {
            this._productRepo.Update(product);
        }

        public void Delete(Product product)
        {
            this._productRepo.Delete(product);
        }

        public List<Product> GetAll()
        {
            return this._productRepo.GetAll().ToList();
        }

        public Product GetById(Guid id)
        {
            return this._productRepo.GetAll()
                .Where(product => product.ProductId.Equals(id)).FirstOrDefault();
        }
    }

}
