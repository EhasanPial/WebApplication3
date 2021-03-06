namespace WebApplication3.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAll();

        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
    }
}
