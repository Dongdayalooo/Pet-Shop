using DemoPetShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoPetShop.Components
{
    public class Page : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public Page(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Page.ToList());
        }
    }
}
