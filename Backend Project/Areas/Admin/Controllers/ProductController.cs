using Backend_Project.DAL;
using Backend_Project.Entities;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController:Controller
    {
        private readonly ShopwiseDbContext _context;

        public ProductController(ShopwiseDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> model = _context.Products.AsEnumerable();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM model = new ProductCreateVM
            {
                Informations = await _context.Informations.ToListAsync(),
                Categories = _context.Categories.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM product)
        {
            ProductCreateVM model = new ProductCreateVM
            {
                Informations = await _context.Informations.ToListAsync(),
                Categories = _context.Categories.ToList()
            };
            if (!ModelState.IsValid) return View(model);
            Product newProduct = new Product();

            

            bool skuResult = _context.Products.Any(p => p.SKU.ToLower() == product.SKU.ToLower());
            if (skuResult)
            {
                ModelState.AddModelError("SKU", "SKU is false");
                return View(model);
            }

            newProduct.SKU = product.SKU;
            newProduct.Name = product.Name;
            newProduct.NewPrice = product.NewPrice;
            newProduct.OldPrice = product.OldPrice;
            newProduct.Offer = product.Offer;
            newProduct.Description = product.Description;

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return Json(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Update(int id, ProductUpdateVM product)
        {
            if (id == 0) return BadRequest();

            ProductUpdateVM model = _context.Products
                                                     .Include(p => p.Image)
                                                     .Include(p => p.ProductInformations)
                                                     .Include(p => p.Category)
                                                     .Select(p => new ProductUpdateVM
            {
                Id = p.Id,
                Name = p.Name,
                NewPrice = p.NewPrice,
                OldPrice = p.OldPrice,
                Offer = p.Offer,
                SKU = p.SKU,
                Description = p.Description,    
                Categories = _context.Categories.ToList(),
                Informations = _context.Informations.ToList()
            }).FirstOrDefault(p => p.Id == id)!;
            return View(model);
        }
    }
}
