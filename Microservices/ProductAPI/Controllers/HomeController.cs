using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Redirect("~/swagger");
    }
}