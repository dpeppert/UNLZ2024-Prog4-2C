using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Google;

namespace LogisticaContainers.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.User.Identities.First().IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task Login()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse")
                });
        }

        [HttpGet("/signin-google")]

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var accessToken = result.Properties.GetTokenValue("access_token");
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(x => new
            {
                x.Issuer,
                x.OriginalIssuer,
                x.Type,
                x.Value,
            });
            /* */

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View("Index");
        }


    }
}
