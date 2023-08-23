using DemoPetShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoPetShop.Components
{
    public class Cat : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public Cat(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Product.Where(p => p.IsCat == true).ToList());
        }
    }
}
