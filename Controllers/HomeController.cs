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
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        private readonly ILogger _logger;
          
        public HomeController(IUserRepository userRepository,
                              IProductRepository productRepository,
                              IPurchaseRepository purchaseHistoryRepository,
                              ILogger<HomeController> logger)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _purchaseRepository = purchaseHistoryRepository;

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Register");
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Products()
        { 
            return View(await _productRepository.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> PurchaseHistory() //change to filter by current user
        {
            _logger.LogInformation("AAAAAAAAA", "");
            return View(await _purchaseRepository.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        { 
            if (ModelState.IsValid)
            {
                var userExists = await _userRepository.GetByFilterAsync(u => u.Login == viewModel.Email) != null;
                if (userExists)
                {
                    _logger.LogInformation("User already exists! ", "");
                    return RedirectToAction("Index", "Home");
                }
                 
                User user = new User
                {
                    Login = viewModel.Email,
                    //Password = new Helpers.PasswordEncode().Encoder(viewModel.Password),
                    Password = viewModel.Password,
                    Nickname = viewModel.Nickname,
                    Phone = viewModel.Phone
                };
                await _userRepository.InsertAsync(user);

                //add singInAsync
            }
            else
            {
                ViewBag.Message = "Check all filds on correct.";
                return View(viewModel);
            }
             
            _logger.LogInformation("User registred! ", "");
            return View("Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userRepository.GetByFilterAsync(
                                    i => i.Login == viewModel.Email 
                                      && i.Password == viewModel.Password);//new PasswordEncode().Encoder(model.Password)
                if (user == null)
                {
                    ViewBag.Message = "Unauthorized: ";
                    return Unauthorized();
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, viewModel.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                    ViewBag.Message = "Val: " + viewModel.RememberMe;

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = viewModel.RememberMe, // "Remember Me"  
                    };

                    await HttpContext.SignInAsync(
                                        CookieAuthenticationDefaults.AuthenticationScheme,
                                        new ClaimsPrincipal(claimsIdentity),
                                        authProperties);

                    return RedirectToAction("Products", "Home");
                } 
            }
            else
            {
                ViewBag.Message = "Username and/or password is incorrect.";

                return View(viewModel);
            } 
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        //temp method
        public async Task<IActionResult> AllUsers()
        {
            return View(await _userRepository.GetAllAsync());
        }
    }
}
