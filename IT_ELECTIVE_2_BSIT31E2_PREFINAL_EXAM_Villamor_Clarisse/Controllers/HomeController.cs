using IT_ELECTIVE_2_BSIT31E2_PREFINAL_EXAM_Villamor_Clarisse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IT_ELECTIVE_2_BSIT31E2_PREFINAL_EXAM_Villamor_Clarisse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
