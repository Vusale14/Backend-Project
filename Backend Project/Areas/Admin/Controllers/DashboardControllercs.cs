using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Project.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    [Authorize]
    public class DashboardController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }
    
}
