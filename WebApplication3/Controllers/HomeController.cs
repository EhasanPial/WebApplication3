using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        // Dependency Injection
        public HomeController(IEmployeeRepository employeeRepository)
        { 
            // Contructor Injection
            _employeeRepository = employeeRepository;
        }

        // Index() handle incoming HTTP request 
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        } 

        // Controller Builds the model er por eta view e pathabe
        public ViewResult Details()
        {
            Employee employee =  _employeeRepository.GetEmployee(1);
            return View(employee);
        }
    }
}
