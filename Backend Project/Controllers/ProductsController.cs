using Backend_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using Backend_Project.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Backend_Project.ViewModels;

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
                                               .Include(p => p.Reviews)
                                               .Include(p=>p.Category)
                                               .Include(p => p.ProductAdditionalInfos)
                                               .ThenInclude(p => p.AdditionalInfo)
                                               .Include(p => p.ProductInformations)
                                               .ThenInclude(p => p.Information)
                                               .FirstOrDefault(p => p.Id == id)!;
            if (product is null) return NotFound();
            return View(product);
        }

        public IActionResult AddWishlist(int id)
        {
            if (id == 0) return NotFound();
            Product product = _context.Products.FirstOrDefault(p => p.Id == id)!;
            if (product is null) return NotFound();

            //Get cookie
            string wishlist = HttpContext.Request.Cookies["wishlist"]!;
            CookieItem cookieProduct = new CookieItem
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.NewPrice,
                Quantity = 1
            };
            WishlistItem wishlistItem = new WishlistItem();
            if (wishlist is null)
            {
                wishlistItem.CookieItems = new List<CookieItem>
                {
                    cookieProduct
                };
            }
            else
            {
                wishlistItem = JsonConvert.DeserializeObject<WishlistItem>(wishlist)!;
                CookieItem existedProduct = wishlistItem.CookieItems.FirstOrDefault(p => p.Id == id)!;

                if (existedProduct is null)
                {
                    wishlistItem.CookieItems.Add(cookieProduct);
                }
            }

            string productsStr = JsonConvert.SerializeObject(wishlistItem);
            HttpContext.Response.Cookies.Append("wishlist", productsStr);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowWishlist()
        {
            var wishlist = HttpContext.Request.Cookies["wishlist"] ?? "";
            WishlistItem convertedProduct = JsonConvert.DeserializeObject<WishlistItem>(wishlist!)!;
            return Json(convertedProduct);
        }

    }
}
