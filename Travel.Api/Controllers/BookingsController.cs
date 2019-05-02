using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Text;
using Travel.Api.Models;

namespace Travel.Api.Models.Controllers
{
	[RoutePrefix("api/example/v1/booking")]
	public class ExampleBookiongsController : ApiController
	{

		/// <summary>
		/// Create Boooking
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost, Route("create")]
		//[TokenAuthentication()]
		//[Authorize(Roles="api.access")]
		public BookingResponse Create(BookingRequest request)
		{
			// crate booking
			var newBooking = request.Booking;

			newBooking.Status = "Completed";
			newBooking.OrderId = "1234";
			var response = new BookingResponse();
			response.Booking = newBooking;

			return response;
		}
	}		
}