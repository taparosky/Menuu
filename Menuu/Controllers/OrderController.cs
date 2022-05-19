using Menuu.Models;
using Menuu.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Menuu.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int totalOrderItems = 0;
            decimal totalAmount = 0.0m;

            //get items from the cart
            List<CartItem> items = _cart.GetCartItems();
            _cart.CartItems = items;

            //check if there are order items
            if(_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "The cart is empty, what about adding some snacks to it?");
            }

            //calculate items total and order amount
            foreach(var item in items)
            {
                totalOrderItems += item.Quantity;
                totalAmount += (item.Snack.Price * item.Quantity);
            }

            //set values to order
            order.OrderItemsSum = totalOrderItems;
            order.OrderTotal = totalAmount;

            //validate order data
            if(ModelState.IsValid)
            {
                //create the order and the details
                _orderRepository.CreateOrder(order);

                //send messages to customer
                ViewBag.CompleteCheckoutMessage = "Thanks for your order :)";
                ViewBag.OrderTotal = _cart.GetCartTotal();

                //clean cart
                _cart.CleanCart();

                //show view with customer and order data
                return View("~/Views/Order/CompleteCheckout.cshtml", order);
            }
            return View(order);
        }
    }
}
