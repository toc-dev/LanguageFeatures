using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ShoppingCart cart
                = new ShoppingCart { Products = Product.GetProducts() };

            Product[] productArray =
            {
                new Product{Name="Kayak", Price=275M},
                new Product {Name = "Lifejacket", Price=48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product{Name = "Corner flag", Price = 34.95M}
            };
            //decimal cartTotal = cart.TotalPrices();
            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            //decimal cartTotal = cart.TotalPrices();
            //return View("Index", new string[] { $"Total: {cartTotal:C2}" });
            return View("Index", new string[]
            {
                //$"Cart Total: {cartTotal:C2}",
                $"Array Total: {arrayTotal:C2}"
            });
            string[] names = new string[3];
            names[0] = "Bob";
            names[1] = "Joe";
            names[2] = "Alice";
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
                ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M}
            };
            return View("Index", products.Keys);

            object[] data = new object[] {275M, 29.95M,
            "apple", "orange", 100, 10};
            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] is decimal d)
                {
                    total += d;
                }
            }
            for (int i = 0; i<data.Length; i++)
            {
                switch (data[i])
                {
                    case decimal decimalValue:
                        total += decimalValue;
                        break;
                    case int intValue when intValue > 50:
                        total += intValue;
                        break;
                }
            }
            return View("Index", new string[] { $"Total: {total:C2}" });

            List<string> results = new List<string>();
            foreach(Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                results.Add($"Name: {name}, Price: {price:C2}, Related: {relatedName}");
            }
            return View(results);
        }
    }
}
