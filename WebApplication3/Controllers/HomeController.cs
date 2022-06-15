﻿using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModels;

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
        [Route("")] // root
        [Route("Home")] // localhost:5000/home
        [Route("Home/Index")]  // localhost:5000/home/index
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAll();
            return View(model);
        }

        // Controller Builds the model er por eta view e pathabe
        public ViewResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
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
                Employee = _employeeRepository.GetEmployee(id),
                PageTitle = "Employee Details"

            };
            return View(homeDetailsViewModel);
        }
    }
}
