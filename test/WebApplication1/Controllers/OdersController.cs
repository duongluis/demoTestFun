using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OdersController
    {
        private readonly CloneEbayDbContext _context;

        public async Task<List<OrderTable>> GetAllProductsAsync()
        {
            return await _context.OrderTables.ToListAsync();
        }
        public async Task<List<OrderItem>> GetAllProductsDetailAsync(int oderID)
        {
            return await _context.OrderItems.Where(o => o.OrderId == oderID).ToListAsync();
        }
    }
}

