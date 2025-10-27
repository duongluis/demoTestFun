using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Views.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Images { get; set; }

        public int CategoryId { get; set; }

        public int SellerId { get; set; }

        public bool IsAuction { get; set; }
        public DateTime? AuctionEndTime { get; set; }
        public bool IsActive { get; set; } = true;

        // For dropdowns
        public List<Category> Categories { get; set; }
        public List<User> Sellers { get; set; }
    }
}
