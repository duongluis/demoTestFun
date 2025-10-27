using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Views.ViewModel;

namespace WebApplication1.Controllers
{
    public class adminController : Controller
    {
        private readonly CloneEbayDbContext _context;

        public adminController(CloneEbayDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Dashboard()
        {
            var dashboard = new DashboardViewModel
            {
                TotalUsers = await _context.Users.CountAsync(),
                TotalProducts = await _context.Products.CountAsync(),
                TotalOrders = await _context.OrderTables.CountAsync(),
                TotalRevenue = await _context.Payments
                    .Where(p => p.Status == "Completed")
                    .SumAsync(p => (int?)p.Amount) ?? 0,
                RecentProducts = await _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Seller)
                    .OrderByDescending(p => p.Id)
                    .Take(10)
                    .ToListAsync(),
                RecentOrders = await _context.OrderTables
                    .Include(o => o.Buyer)
                    .OrderByDescending(o => o.OrderDate)
                    .Take(10)
                    .ToListAsync()
            };

            return View(dashboard);
        }

    }
}
