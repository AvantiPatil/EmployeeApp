using EmployeeApp.Models;

namespace EmployeeApp.Repositories.Interaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
