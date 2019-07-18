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
        public IActionResult Index()
        {
            return View();
        } 
    }
}
