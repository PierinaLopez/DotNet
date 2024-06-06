using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;

        public ShoppingCartController(StoreContext context)
        {
            _context = context;
        }

        // GET: /ShoppingCart/
        public IActionResult Index()
        {
            var cart = new ShoppingCart(HttpContext, _context);
            var cartItems = cart.GetCartItems();
            return View(cartItems);
            /* return View(await _context.CartItems.ToListAsync());*/
        }

        public IActionResult AddToCart(int id)
        {
            //Retrieve the album from the database
            var newAlbum = _context.Albums.Single(m => m.AlbumID == id);

            //Add it to the shopping cart
            var cart = new ShoppingCart(HttpContext, _context);

            cart.AddToCart(newAlbum);

            //Go back to the main store page for more shopping 
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = new ShoppingCart(HttpContext, _context);
            cart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddOne(int id)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            shoppingCart.ChangeCount(id, 1);
            return RedirectToAction("Index");
        }



        public IActionResult RemoveOne(int id)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            shoppingCart.ChangeCount(id, -1);
            return RedirectToAction("Index");
        }

    }
}
