using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        private readonly ILogger _logger;

        public ProductController(IProductRepository productRepository,
                              IPurchaseRepository purchaseHistoryRepository,
                              ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _purchaseRepository = purchaseHistoryRepository;

            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProductsList(string filterCategory, string sortOrder)
        { 
            ViewData["PriceSort"] = sortOrder == "price" ? "price_desc" : "price";

            IQueryable<Product> products; 
            if (!String.IsNullOrEmpty(filterCategory))
            { 
                products = _productRepository.GetListByFilter(c => c.Category.Name == filterCategory);
            }
            else
            {
                products = _productRepository.GetAll();
            }

            if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "price":
                        products = products.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    default: break;
                }
            }

            IEnumerable<Product> productsList = await _productRepository.GetAllAsync(products);

            return View(productsList);          //may be should convert to IEnumerable<ProductViewModel>,
                                                //but it's expensive
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> PurchaseHistory()
        {
            string userLogin = User.Identity.Name;
            return View(await _purchaseRepository.GetListByFilterAsync(userLogin));
        }

        public async Task<IActionResult> Purchase(int? id)
        {
            int productId = id ?? 0;
            if (productId == 0)
            {
                return NotFound();
            }

            string userLogin = User.Identity.Name; 

            bool success = await _purchaseRepository.InsertAsync(userLogin, productId);

            if (!success)
            {
                return BadRequest();
            }

            Product product = await _productRepository.GetByIdAsync(productId);

            ViewData["Info"] = "Product successfully added to your purchases.";

            return View("SuccessfulPurchase", product);    //may be should convert to ProductViewModel
                                                           //to maintain a common style, but it seems strange
        }
    }
}