using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class CurrencyController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currencyapi-net.p.rapidapi.com/rates?output=JSON&base=USD"),
                Headers =
    {
        { "X-RapidAPI-Key", "91f6ab702dmshb66577b2fc1975cp1d4814jsnbd9cb4d60935" },
        { "X-RapidAPI-Host", "currencyapi-net.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CurrencyViewModel>(body);
                return View(values);
            }
        }
    }
}
