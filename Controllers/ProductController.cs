using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CoffeeShopMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private CoffeeShopContext _coffeeShopContext;

        public ProductController(ILogger<ProductController> logger, CoffeeShopContext newCoffeeShopContext)
        {
            _logger = logger;
            _coffeeShopContext = newCoffeeShopContext;
        }

        public IActionResult ProductIndex()
        {
            var productList = _coffeeShopContext.Products.ToArray();
            return View(productList);
        }
        public IActionResult Details(int Id)
        {
            Product productDescription = null;
            var productList = _coffeeShopContext.Products.ToArray();
            foreach (var currProduct in productList)
            {
                if (currProduct.Id == Id)
                {
                    productDescription = currProduct;
                    break;
                }
            }
            if (productDescription != null)
            {
                return View("Details", productDescription);
            }
            else
            {
                throw new Exception("I do not recognize that product");
            }
        }
    }
}