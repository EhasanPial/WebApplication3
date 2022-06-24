namespace WebApplication3.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;
        public MockEmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee(){ Id = 1, Name = "Roni",Department =Dept.HR, Email="pialkhanpial@gmail.com"},
                new Employee(){ Id = 2, Name = "Roni2",Department =Dept.IT, Email="subahpial@gmail.com"}
            };
        }

        public Employee Add(Employee employee)
        {
             employee.Id = employees.Max(e => e.Id) + 1;
             employees.Add(employee);
             return employee;
        }

        public Employee Delete(int id)
        {
           Employee employee = employees.FirstOrDefault(e => e.Id == id);
           if(employee != null)
            {
                employees.Remove(employee);
            }

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;

        }

        public Employee GetEmployee(int id)
        { 
            return this.employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChange)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == employeeChange.Id);
            if (employee != null)
            {
                employee.Email = employeeChange.Email;
                employee.Department = employeeChange.Department;
                employee.Name = employeeChange.Name;
                 
            }

            return employee;
        }
    }
}
