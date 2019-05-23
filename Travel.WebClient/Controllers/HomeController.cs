using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Travel.WebClient.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
			var model = new TravelModel();

			var api = new TravelApi("https://travel-web-api.azurewebsites.net/", new System.Net.Http.HttpClient());

			var response = await api.Products_ListAsync();

			if (response != null)
			{
				model.Products = response.Products;
			}

			return View(model);
        }
    }
}