using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    //public interface IEmployeeService
    //{
    //    public void Create(Employee employee);
    //    public void Update(Employee employee);
    //    public void Delete(Employee employee);
    //    public List<Employee> GetAll();
    //}
    public class EmployeeService /*: IEmployeeService*/:RepositoryBase<Employee>
    {
        //private readonly RepositoryBase<Employee> _emloyeeService;
        //public EmployeeService() { }

        //public EmployeeService(RepositoryBase<Employee> emloyeeService)
        //{
        //    _emloyeeService = emloyeeService;
        //}

        //public void Create(Employee employee)
        //{
        //    _emloyeeService.Create(employee);
        //}

        //public void Delete(Employee employee)
        //{
        //    _emloyeeService.Delete(employee);
        //}

        //public List<Employee> GetAll()
        //{
        //    return _emloyeeService.GetAll().ToList();
        //}

        //public void Update(Employee employee)
        //{
        //    _emloyeeService.Update(employee);
        //}
    }

}
