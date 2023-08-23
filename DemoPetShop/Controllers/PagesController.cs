using DemoPetShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoPetShop.Controllers
{
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Pages
        public async Task<IActionResult> UserView()
        {
           return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Page == null)
            {
                return NotFound();
            }

            var page = await _context.Page
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }
    }
}
