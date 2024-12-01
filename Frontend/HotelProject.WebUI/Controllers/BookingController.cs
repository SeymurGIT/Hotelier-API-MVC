using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }       
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Gözləməkdə";

            createBookingDto.BookingDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy HH:mm"));

            createBookingDto.CheckIn = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy HH:mm"));

            createBookingDto.CheckOut = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy HH:mm"));

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");

            await client.PostAsync("https://hoteliersweb.azurewebsites.net/api/Booking", stringContent);

            return RedirectToAction("Index", "Default");
        }
        
    }
}
