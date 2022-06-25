using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.wwwroot.Controllers
{
    [Authorize]
    [Route("[controller]")]
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
        [Route("~/")] // "localhost:5000/"   // root of website
        [Route("")] // "localhost:5000/home" [Route("/Home")]  
        [Route("[action]")]  // localhost:5000/home/index
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAll();
            return View(model);
        }


        [AllowAnonymous]
        [Route("Details/{id?}")]
        // Controller Builds the model er por eta view e pathabe
        public ViewResult Details(int? id)
        {
            Employee employee = _employeeRepository.GetEmployee(id ?? 1);
            // data pass kortechi.
            // 1. ViewData diye data pass - jeta key,value er mto. mane dictonary
            ViewData["Employee"] = employee;
            // Page Title o pathacchi. joss na?
            ViewData["PageTitle"] = "Employee Details";

            ViewBag.Employee = employee;
            ViewBag.PageTitle = "Employee Details";



            //Strongly Typed View // View(employee) 


            //View model diye sob data pass, page title o
            //bascially view model holo ami object + other data
            // pathaite cacchi tai ekta object banay pathy dibo
            //jeta ViewModel
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details",


            };
            return View(homeDetailsViewModel);
        }

        [Route("Create")]
        [HttpGet]
        [Authorize]

        public ViewResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [Authorize]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { id = newEmployee.Id });

            }

            return View();


        }

        [Route("Edit")]
        [HttpGet]
        [Authorize]


        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel editViewModel = new EmployeeEditViewModel
            {
                Id = id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                PhotoPath = employee.PhotoPath

            };
            return View(editViewModel);
        }


        [Route("Edit")]
        [HttpPost]
        [Authorize]

        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {

                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.PhotoPath = model.PhotoPath;
                employee.Name = model.Name;

                _employeeRepository.Update(employee);
                return RedirectToAction("index", new { id = employee.Id });

            }

            return View();


        }


    }
}
