using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    { 
        private readonly IUserRepository _userRepository;

        private readonly ILogger _logger;

        public AccountController(IUserRepository userRepository,
                                ILogger<HomeController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userRepository.GetByFilterAsync(u => u.Login == viewModel.Email);
                if (user != null)
                {
                    ModelState.AddModelError("", "User already exists."); 

                    return RedirectToAction("Index", "Home");
                }

                User newUser = new User
                {
                    Login = viewModel.Email,
                    //Password = new Helpers.PasswordEncode().Encoder(viewModel.Password),
                    Password = viewModel.Password,
                    Nickname = viewModel.Nickname,
                    Phone = viewModel.Phone
                };

                bool success = await _userRepository.InsertAsync(newUser);

                if (!success)
                {
                    return BadRequest(); 
                }

                await Authenticate(viewModel.Email);
            }
            else
            {
                ModelState.AddModelError("", "Check all filds on correct.");

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
                    ModelState.AddModelError("", "Username and/or password is incorrect.");
                }
                else
                {
                    await Authenticate(viewModel.Email, viewModel.RememberMe);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(viewModel);
        }

        private async Task Authenticate(string userEmail, bool rememberMe = false)
        {
            var claims = new List<Claim> {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userEmail)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
             
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe
            };

            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
         
        //temp method del
        public async Task<IActionResult> AllUsers()
        {
            return View(await _userRepository.GetAllAsync());
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            string userLogin = User.Identity.Name;

            User user = await _userRepository.GetByFilterAsync(i => i.Login == userLogin);

            return View(user);
        }

        [HttpPost] 
        public async Task<IActionResult> Profile(User user)
        {
            bool success = await _userRepository.UpdateAsync(user);

            if (!success)
            {
                return BadRequest();
            }

            ViewData["Info"] = "Your profile has been successfully changed.";

            return View();
        }
    }
}