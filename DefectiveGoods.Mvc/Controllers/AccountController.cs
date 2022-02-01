using Microsoft.AspNetCore.Authentication.Cookies;
using DefectiveGoods.Core.Users;
using DefectiveGoods.Mvc.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using DefectiveGoods.Core;
using DefectiveGoods.Core.Branches;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DefectiveGoods.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly DefectiveGoodsContext _context;

        public AccountController(IUserManager userManager, DefectiveGoodsContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel input)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.IsExist(input.Login, input.Password))
                {
                    await Authentication(input.Login);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(input);
        }

        private async Task Authentication(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public IActionResult Register()
        {
            IList<Branch> branches = _context.Branches.ToList();
            ViewBag.Branches = new SelectList(branches, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel input)
        {
            if (ModelState.IsValid)
            {
                
            }

            IList<Branch> branches = _context.Branches.ToList();
            ViewBag.Branches = new SelectList(branches, "Id", "FullName");
            return View(input);
        }


    }
}
