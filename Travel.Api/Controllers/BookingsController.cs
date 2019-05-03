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
	[RoutePrefix("api/bookings")]
	public class BookingsController : ApiController
	{
		/// <summary>
		/// Create Boooking
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost, Route("")]
		[TokenAuthentication()]
		[Authorize(Roles="api.access")]
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

		[HttpGet, Route("{id}")]
		[TokenAuthentication()]
		[Authorize(Roles = "api.access")]
		public BookingResponse Detail(string id)
		{
			// crate booking
			var newBooking = new Booking();
			var response = new BookingResponse();
			response.Booking = newBooking;

			return response;
		}

		[HttpPost, Route("{id}/cancel")]
		[TokenAuthentication()]
		[Authorize(Roles = "api.access")]
		public BookingResponse Cancel(string id)
		{
			// crate booking
			var newBooking = new Booking();
			newBooking.Status = "Cancled";
			var response = new BookingResponse();
			response.Booking = newBooking;

			return response;
		}
	}		
}