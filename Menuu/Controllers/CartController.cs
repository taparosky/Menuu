using Menuu.Models;
using Menuu.Repositories.Interfaces;
using Menuu.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Menuu.Controllers
{
    public class CartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly Cart _cart;

        public CartController(ISnackRepository snackRepository, Cart cart)
        {
            _snackRepository = snackRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var items = _cart.GetCartItems();
            _cart.CartItems = items;

            var cartVM = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };

            return View(cartVM);
        }

        [Authorize]
        public RedirectToActionResult AddItemToCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == snackId);

            if(selectedSnack != null)
            {
                _cart.AddToCart(selectedSnack);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoveItemFromCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == snackId);

            if (selectedSnack != null)
            {
                _cart.RemoveFromCart(selectedSnack);
            }

            return RedirectToAction("Index");
        }
    }
}
