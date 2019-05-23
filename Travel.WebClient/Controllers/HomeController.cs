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
		//public TravelApi api = new TravelApi("https://travel-web-api.azurewebsites.net/", new System.Net.Http.HttpClient());
		public TravelApi api = new TravelApi();

		// GET: Home
		public async Task<ActionResult> Index()
        {
			var model = new TravelModel();

			var response = await api.ProductListAsync();
			if (response != null)
			{
				model.Products = response;
			}

			return View(model);
        }

		public async Task<ActionResult> Detail(int id)
		{
			var model = new TravelModel();

			var response = await api.ProductDetailAsync(id);

			if (response != null)
			{
				model.Products = response;
			}

			return View(model);
		}

		[HttpGet]
		public async Task<ActionResult> Booking(string id)
		{
			var model = new BookingModel();

			var response = await api.Bookings_DetailAsync(id);

			if (response != null)
			{
				model.Booking = response.FirstOrDefault();
			}

			return View(model);
		}

		[HttpPost]
		public async Task<ActionResult> Booking(BookingModel model)
		{
			// Create new booking request
			var booking = new Booking()
			{
				Customer = new Customer() { Email = model.Email },
				Items = new List<BookingItem>()
				  {
					   new BookingItem() {
							ProductNumber  = model.ProductNumber,
							Quantity = model.Quantity,
							 UseDate = DateTime.Today
					   }
				  }
			};

			// create booking
			var response = await api.Bookings_CreateAsync(booking);

			if (response != null)
			{
				model.Booking = response.FirstOrDefault();
			}

			return View(model);
		}
	}
}