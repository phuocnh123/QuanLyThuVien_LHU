using Microsoft.AspNetCore.Mvc;

namespace QuanLyThuVienLHU.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
