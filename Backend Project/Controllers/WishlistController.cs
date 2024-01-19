using Backend_Project.DAL;
using Backend_Project.Entities;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backend_Project.Controllers
{
    public class WishlistController:Controller
    {
        private readonly ShopwiseDbContext _context;

        public WishlistController(ShopwiseDbContext context)
        {
            _context = context;
         
        }
        public IActionResult Index()
        {
            return View();
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
                NewPrice = product.NewPrice
            };
            WishlistItem wishlistItem = new WishlistItem();
            if (wishlistItem is null)
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

            //Add to cookie
            string productsStr = JsonConvert.SerializeObject(wishlistItem);
            HttpContext.Response.Cookies.Append("basket", productsStr);

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
