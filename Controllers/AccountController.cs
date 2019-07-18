using System;
using System.Collections.Generic; 
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models.Data;
using OnlineStore.Models.Helpers;
using OnlineStore.Models.Interfaces;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    { 
        private readonly IUserRepository _userRepository; 
        private readonly ILogger _logger;

        public AccountController(IUserRepository userRepository, ILogger<AccountController> logger)
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

                    return View(viewModel);
                }

                User newUser = new User
                {
                    Login = viewModel.Email,
                    Password = PasswordEncode.Encoder(viewModel.Password), 
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
                return View(viewModel);
            }

            _logger.LogInformation("User registred! ", "");

            return RedirectToAction("Index", "Home");
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
                User user = await _userRepository.GetByFilterAsync(u => 
                                                         u.Login == viewModel.Email
                                                      && u.Password == PasswordEncode.Encoder(viewModel.Password));
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

        //cookie authentication without ASP.NET Core Identity
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            string userLogin = User.Identity.Name;

            User user = await _userRepository.GetByFilterAsync(u => u.Login == userLogin);
            if (user == null)
            {
                return NotFound();
            }

            UserViewModel viewModel = new UserViewModel {
                Nickname = user.Nickname,
                Phone = user.Phone
            };

            return View(viewModel);
        }

        [HttpPost] 
        public async Task<IActionResult> Profile(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                string userLogin = User.Identity.Name;

                bool success = await _userRepository.UpdateAsync(userLogin, user);

                _logger.LogInformation("SUCCESS! " + success, "");

                if (!success)
                {
                    return BadRequest();
                }

                ViewData["Info"] = "Your profile has been successfully changed.";
            } 
            return View(user);
        }
         
        //test method
        public async Task<IActionResult> AllUsers()
        {
            return View(await _userRepository.GetAllAsync());
        }
    }
}