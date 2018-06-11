using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FruitStore.Models;

namespace FruitStore.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> _products;

        public ProductController()
        {

            _products = new List<Product>();

            _products.Add(new Product
            {

                ID = 1,
                Name = "Apple",
                Description = "Honey Crisp Apple",
                Image="/images/apple.jpeg",
                Price=2

            });

            _products.Add(new Product
            {

                ID = 2,
                Name = "Kiwi",
                Description = "Tasty Kiwi",
                Image = "/images/kiwi.jpeg",
                Price = 3

            });

        }

        public IActionResult Details(int? ID)
        {
            if (ID.HasValue)
            {
                Product p = _products.Single(x => x.ID == ID.Value);
                return View(p);
            }
            return NotFound();
        }

        public IActionResult Index()
        {
            return View(_products);
        }
    }
}