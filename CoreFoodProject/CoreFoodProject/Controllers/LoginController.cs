using CoreFoodProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreFoodProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();  

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Index(Admin p)
		{
            var userValu = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);

            if(userValu != null) 
            {
               var claims = new List<Claim>()
               {
                   new Claim(ClaimTypes.Name, p.AdminUserName),
               };

                var useridentity = new ClaimsIdentity(claims,"Login");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Foot");
            }

			return View();
		}
		[HttpGet]
		public async Task<IActionResult> Logout()
		{
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


			return RedirectToAction("Index","Login");
		}
	}
}
