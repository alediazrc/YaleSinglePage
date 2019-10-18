using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index(OAuth _responseOauth)
        {
            var x = _responseOauth;
            return View();
        }
        [AllowAnonymous]
        public ActionResult Allows(Accounts _accounts)
        {
            ViewBag.Title = "Bienvenide" + _accounts.FirstName;
            return RedirectToAction("OAuth", "Home", _accounts);
        }

        [AllowAnonymous]
        public async Task<ActionResult> OAuth(Accounts _accounts)
        {
            ViewBag.Title = "Bienvenide Oauth" + _accounts.FirstName;
            var url = "http://localhost:52472/api/YaleConnect";
            var apiUrl = url + "/GetAccessToken?" + "AccountID = " + _accounts.AccountID.ToString();
            Uri address = new Uri(apiUrl);
            HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);

            var respuesta = responseMessage.Content.ReadAsAsync<Accounts>();
            return View();
        }
    }
}
