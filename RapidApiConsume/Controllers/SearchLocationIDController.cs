using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {

        public async Task<IActionResult> Index(string cityName, string message)
{
    List<DestinationIDLocationViewModel> destinationViewModel = new List<DestinationIDLocationViewModel>();

    if (!string.IsNullOrEmpty(cityName))
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
            Headers =
            {
                { "X-RapidAPI-Key", "91f6ab702dmshb66577b2fc1975cp1d4814jsnbd9cb4d60935" },
                { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
            },
        };

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            destinationViewModel = JsonConvert.DeserializeObject<List<DestinationIDLocationViewModel>>(body);
        }
    }
    var tupleModel = Tuple.Create(cityName, destinationViewModel.Take(1).ToList());
    return View(tupleModel); // Pass tuple model to the view

}

    }
}
