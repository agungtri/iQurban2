using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using iQurban.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using iQurban.CustomAttributes;

namespace iQurban.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            User objLoggedInUser = new User();
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = claimsIdentity.Claims;

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    foreach (var claim in userClaims)
                    {
                        var cType = claim.Type;
                        var cValue = claim.Value;
                        switch (cType)
                        {
                            case "USERID":
                                objLoggedInUser.USERID = cValue;
                                break;
                            case "EMAILID":
                                objLoggedInUser.EMAILID = cValue;
                                break;
                            case "PHONE":
                                


                                objLoggedInUser.PHONE = cValue;
                                break;
                            case "DIRECTOR":
                                objLoggedInUser.ACCESS_LEVEL = cValue;
                                break;
                            case "SUPERVISOR":
                                objLoggedInUser.ACCESS_LEVEL = cValue;
                                break;
                            case "ANALYST":
                                objLoggedInUser.ACCESS_LEVEL = cValue;
                                break;
                            default:
                                break;
                        }
                    }
                    ViewBag.UserRole = GetRole();
                }
            }

            return View("Index", objLoggedInUser);
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        public JsonResult EndSession()
        {
            HttpContext.Session.Clear();
            return Json(new { result = "success" });
        }

        private string GetRole()
        {
            if (this.HavePermission(Roles.DIRECTOR))
            {
                return " - DIRECTOR";
            }
            if (this.HavePermission(Roles.SUPERVISOR))
            {
                return " - SUPERVISOR";
            }
            if (this.HavePermission(Roles.ANALYST))
            {
                return " - ANALYST";
            }
            return null;

        }

        public IActionResult LoginUser(User user)
        {
            TokenProvider _tokenProvider = new TokenProvider();
            var userToken = _tokenProvider.LoginUser(user.USERID.Trim(), user.PASSWORD.Trim());
            if (userToken != null)
            {
                //Save token in session object
                HttpContext.Session.SetString("JWToken", userToken);
            }
            return Redirect("~/Home/Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
