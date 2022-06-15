using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class DepartmentController : Controller
{
     public string List()
    {
        return "List() of departmentController";
    }
    public string Details()
    {
        return "Details() of DepartmentController";
    }
}
