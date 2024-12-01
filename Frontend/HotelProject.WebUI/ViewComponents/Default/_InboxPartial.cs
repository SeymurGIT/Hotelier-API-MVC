using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _InboxPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _InboxPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var responseInboxMessage = await client.GetAsync("https://hoteliersweb.azurewebsites.net/api/Contact/GetContactCount");

            var client2 = new HttpClient();
            var responsonseSentMessage = await client.GetAsync("https://hoteliersweb.azurewebsites.net/api/SendMessage/GetSentMessagesCount");

            if(responseInboxMessage.IsSuccessStatusCode && responsonseSentMessage.IsSuccessStatusCode)
            {
                var jsonInboxData = await responseInboxMessage.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonInboxData ?? "0";

                var jsonSentData = await responsonseSentMessage.Content.ReadAsStringAsync();
                ViewBag.sentMessagesCount = jsonSentData ?? "0";


            }
            return View();
        }
    }
}
