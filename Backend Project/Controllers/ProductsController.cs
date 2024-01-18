using Backend_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using Backend_Project.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_Project.Controllers
{
    public class ProductsController:Controller
    {
        private readonly ShopwiseDbContext _context;
        public ProductsController (ShopwiseDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Product> products= _context.Products.ToList();
                return View(products);
        }
        public IActionResult Details(int id)
        {
            if (id == 0) return BadRequest();
            Product product = _context.Products
                                                .Include(p=>p.Category)
                                               .Include(p => p.ProductAdditionalInfos)
                                               .ThenInclude(p => p.AdditionalInfo)
                                               .Include(p => p.ProductInformations)
                                               .ThenInclude(p => p.Information)
                                               .FirstOrDefault(p => p.Id == id)!;
            if (product is null) return NotFound();
            return View(product);
        }
    }
}
