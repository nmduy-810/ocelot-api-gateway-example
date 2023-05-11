using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Redirect("~/swagger");
    }
}