using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("BookingList")]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            var bookings = new Booking()
            {
                BookingDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy HH:mm")),
                CheckIn = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy HH:mm")),
                CheckOut = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy HH:mm"))
            };
            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }
        [HttpGet("Last6Bookings")]
        public IActionResult Last6Bookings()
        {
            var values = _bookingService.TLast6Bookings();
            return Ok(values);
        }
        [HttpPut("BookingApproved")]
        public IActionResult BookingApproved(Booking booking)
        {
            _bookingService.TApprovedReservation(booking);
            return Ok();
        }
        [HttpGet("BookingApproved2")]
        public IActionResult BookingApproved2(int id)
        {
            _bookingService.TApprovedReservation2(id);
            return Ok();
        }

        [HttpGet("BookingCanceled")]
        public IActionResult BookingCanceled(int id)
        {
            _bookingService.TCanceledReservation(id);
            return Ok();
        }

        [HttpGet("BookingHold")]
        public IActionResult BookingHold(int id)
        {
            _bookingService.THoldReservation(id);
            return Ok();
        }

    }
}
