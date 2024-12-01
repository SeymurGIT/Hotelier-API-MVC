using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://hoteliersweb.azurewebsites.net/api/Contact");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> SentBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://hoteliersweb.azurewebsites.net/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSentBoxDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> MessageDetailsBySentBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://hoteliersweb.azurewebsites.net/api/SendMessage/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://hoteliersweb.azurewebsites.net/api/Contact/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessage)
        {
            createSendMessage.SenderMail = "admin@hotelier.az";
            createSendMessage.SenderName = "Hotelier";
            createSendMessage.Date = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy HH:mm"));
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://hoteliersweb.azurewebsites.net/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Inbox");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ReplyMessageByID(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://hoteliersweb.azurewebsites.net/api/Contact/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ReplyMessageByID>(jsonData);
                
                var replyDto = new ReplyMessageByID
                {
                    ContactID = values.ContactID,
                    Name = values.Name,
                    Mail = values.Mail,
                    Date = values.Date,
                    Subject = values.Subject,
                    Message = values.Message,
                    // Initialize an empty SendMessage DTO for the response
                    SendMessage = new CreateSendMessageDto()
                };
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ReplyMessageByID(ReplyMessageByID replyMessage)
        {
            if (!ModelState.IsValid)
                return View(replyMessage);

            var replyDto = new CreateSendMessageDto
            {
                SenderMail = "admin@hotelier.az",
                SenderName = "Hotelier",
                ReceiverMail = replyMessage.Mail,
                ReceiverName = replyMessage.Name,
                Content = replyMessage.SendMessage.Content,
                Title = replyMessage.Subject,
                Date = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy HH:mm"))
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(replyDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://hoteliersweb.azurewebsites.net/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Inbox");
            }
            return View(replyMessage);
        }

        public PartialViewResult AdminContactNavPanePartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminContactCategoryPanePartial()
        {
            return PartialView();
        }
    }

}
