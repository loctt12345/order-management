using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Services
{
    public interface IEmployeeService
    {
        public void Create(Employee employee);
        public void Update(Employee employee);
        public void Delete(Employee employee);
        public List<Employee> GetAll();
        public Employee GetById(String id);

    }

    public class EmployeeService : IEmployeeService
    {
        private RepositoryBase<Employee> _employeeRepo = new RepositoryBase<Employee>();
        public void Create(Employee employee) { }
        public void Update(Employee employee) { }
        public void Delete(Employee employee) { }

        public List<Employee> GetAll()
        {
            return this._employeeRepo.GetAll().ToList();
        }

        public Employee GetById(String id)
        {
            return this._employeeRepo.GetAll().Where(e => e.EmployeeId.Equals(id)).FirstOrDefault();
        }
    }
}
