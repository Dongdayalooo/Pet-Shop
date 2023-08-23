using DemoPetShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoPetShop.Components
{
    public class Dog : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public Dog(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Product.Where(p => p.IsDog == true).ToList());
        }
    }
}
