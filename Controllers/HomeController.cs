using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.Models;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {  
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        private readonly ILogger _logger;
          
        public HomeController(IProductRepository productRepository,
                              IPurchaseRepository purchaseHistoryRepository,
                              ILogger<HomeController> logger)
        { 
            _productRepository = productRepository;
            _purchaseRepository = purchaseHistoryRepository;
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Home");
        }
        
        [HttpGet]
        [Authorize] 
        public async Task<IActionResult> Products(string filterCategory, string sortOrder)
        {
            ViewData["PriceSort"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "price";
             
            var products = await _productRepository.GetAllAsync();

            if (!String.IsNullOrEmpty(filterCategory))
            { 
                products = products.Where(c => c.Category.Name == filterCategory);
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
             
            return View(products);
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
            else
            { 
                string userLogin = User.Identity.Name;
                Product product = await _productRepository.GetByIdAsync(productId);

                bool success = await _purchaseRepository.InsertAsync(userLogin, product);

                if (!success)
                {
                    return BadRequest();
                }

                return View("SuccessfulPurchase", product);
            }  
        } 
    }
}
