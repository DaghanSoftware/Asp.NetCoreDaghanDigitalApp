using DaghanDigital.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DaghanDigital.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProductWithCategory());
        }
    }
}
