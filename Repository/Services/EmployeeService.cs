using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IEmployeeService
    {
        public void Create(Employee employee);
        public void Update(Employee employee);
        public void Delete(Employee employee);
        public List<Employee> GetAll();
    }
    public class EmployeeService : IEmployeeService
    {
        private RepositoryBase<Employee> _employeeRepo = new RepositoryBase<Employee>();
        public EmployeeService() { }
        public void Create(Employee employee)
        {
            _employeeRepo.Create(employee);
        }

        public void Delete(Employee employee)
        {
            _employeeRepo.Delete(employee);
        }

        public List<Employee> GetAll()
        {
           return _employeeRepo.GetAll().ToList();
        }

        public void Update(Employee employee)
        {
            _employeeRepo.Update(employee);
        }
    }
}
