using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController
    {
        private readonly CloneEbayDbContext _context;

        private async Task<int> CountAccount()
        {
            return await _context.Users.CountAsync();
        }
    }
}
