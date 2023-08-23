using DemoPetShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoPetShop.Components
{
    public class Search: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public Search(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Product.ToList());
        }
    }
}
