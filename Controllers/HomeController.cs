using Microsoft.AspNetCore.Mvc;
using Price_Quotation_App.Models;

namespace Price_Quotation_App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PriceQuotationModel());
        }

        [HttpPost]
        public IActionResult Index(PriceQuotationModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }
    }
}
