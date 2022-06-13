﻿namespace WebApplication3.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public List<Employee> employees;
        public MockEmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee(){ Id = 1, Name = "Pial",Department ="CSE", Email="pialkhanpial@gmail.com"},
                new Employee(){ Id = 2, Name = "Subah",Department ="CSE", Email="subahpial@gmail.com"}
            };
        }
        public Employee GetEmployee(int id)
        { 
            return this.employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
