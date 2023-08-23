using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoPetShop.Data;
using DemoPetShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using DemoPetShop.Repositories.Abstract;

namespace DemoPetShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment )
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Employees
        public async Task<IActionResult> Index()
        {
              return _context.Employees != null ? 
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
        }

        // GET: Admin/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Admin/Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,ImageFile")] Employee employee)
        {

            if (ModelState.IsValid)
            {

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost]
        [Route("uploadfile-voi-image")]
        public async Task<IActionResult> PostWithImage([FromForm] Employee employee)
        {
            var findE = _context.Employees.Find(employee.EmployeeId);
            if(findE != null)
            {
                return Ok(" nguoi dung nay da co roi");
            }
            else
            {
                var employees = new Employee { EmployeeId = employee.EmployeeId, EmployeeName = employee.EmployeeName };
                // su ly anh
                if(employee.ImageFile.Length>0)
                { 
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "/img/hero/", employee.ImageFile.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                       await employee.ImageFile.CopyToAsync(stream);
                    }
                    employee.EmployeeImage = "/img/hero/" + employee.ImageFile.FileName;
                }
                else
                {
                    employee.EmployeeImage = "";
                }

                _context.Add(employee);
                _context.SaveChangesAsync();
                return Ok(employees);
            }
        }
      
        // GET: Admin/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Admin/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,EmployeeImage")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Admin/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Admin/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
