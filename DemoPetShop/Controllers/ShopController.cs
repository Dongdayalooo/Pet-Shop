using DemoPetShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoPetShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string keywords)
        {
            var applicationDbContext = _context.Product.Where(p => p.ProductName.Contains(keywords));
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
