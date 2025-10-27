using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Views.ViewModel;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly CloneEbayDbContext _context;
        private readonly ProductViewModel _product;

        public ProductController(CloneEbayDbContext context)
        {
            _context = context;
        }

        public async Task<Boolean> hideProduct(int productID)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product != null)
            {
                //product.IsActive = false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteProduct(int productID)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var product = await _context.Products.Include(p => p.Category).ToListAsync();
            
            return product;
        }

        public async Task<IActionResult> Product()
        {
            var products = await GetAllProductsAsync();
            return View(products);
        }

    }
}
