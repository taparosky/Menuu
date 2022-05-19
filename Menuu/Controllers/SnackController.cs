using Microsoft.AspNetCore.Mvc;
using Menuu.Repositories.Interfaces;
using Menuu.ViewModels;
using Menuu.Models;

namespace Menuu.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;

            if(string.IsNullOrEmpty(category))
            {
                snacks = _snackRepository.Snacks.OrderBy(s => s.SnackId);
                currentCategory = "All snacks";

            }
            else
            {
                snacks = _snackRepository.Snacks.Where(s => s.Category.CategoryName.Equals(category)).OrderBy(c => c.Category.CategoryName);
                currentCategory = category;
            }

            var snacksListViewModel = new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = currentCategory
            };

            return View(snacksListViewModel);
        }

        public IActionResult Details(int snackId)
        {
            var snack = _snackRepository.Snacks.FirstOrDefault(s => s.SnackId == snackId);
            return View(snack);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;

            if(string.IsNullOrEmpty(searchString))
            {
                snacks = _snackRepository.Snacks.OrderBy(o => o.SnackId);
                currentCategory = "All snacks";
            }
            else
            {
                snacks = _snackRepository.Snacks.Where(o => o.SnackName.ToLower().Contains(searchString.ToLower()));

                if (snacks.Any())
                    currentCategory = "Snacks";
                else
                    currentCategory = "No snacks were found";

            }

            return View("~/Views/Snack/List.cshtml", new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = currentCategory
            });
        }
    }
}
