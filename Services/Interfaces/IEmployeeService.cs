using EmployeeApp.Models;

namespace EmployeeApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
