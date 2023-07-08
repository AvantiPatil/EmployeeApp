using EmployeeApp.Models;
using EmployeeApp.Repositories.Interaces;
using EmployeeApp.Services.Interfaces;

namespace EmployeeApp.Services.Implementations
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _IEmployeeRepository;
        public EmployeeService(IEmployeeRepository IEmployeeRepository)
        {
            _IEmployeeRepository = IEmployeeRepository;
        }
        public Employee GetEmployeeById(int id)
        {
           return _IEmployeeRepository.GetEmployeeById(id);
        }

        public List<Employee> GetAllEmployees()
        {
           return _IEmployeeRepository.GetAllEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            _IEmployeeRepository.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
           _IEmployeeRepository.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _IEmployeeRepository.DeleteEmployee(id);
        }
    }
}
