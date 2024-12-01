using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using HotelProject.WebUI.Dtos.SocialProfileDto;
using System.Collections.Generic;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSocialCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scrapper-posts-reels-stories-downloader.p.rapidapi.com/profile_by_username?username=seymur.halley20"),
                Headers =
        {
            { "x-rapidapi-key", "9bba90c42amsh40d2cc1a04724d6p1ccf8cjsn6cc84ce96869" },
            { "x-rapidapi-host", "instagram-scrapper-posts-reels-stories-downloader.p.rapidapi.com" },
        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                InstagramProfileDto instagram = JsonConvert.DeserializeObject<InstagramProfileDto>(body);
                ViewBag.instagramFollowers = instagram.follower_count;
                ViewBag.instagramFollowings = instagram.following_count;
            }
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yt-api.p.rapidapi.com/channel/about?id=UC27OaqO-sizDB1xrni7zjKA&forUsername=seymur.halley"),
                Headers =
    {
        { "x-rapidapi-key", "9bba90c42amsh40d2cc1a04724d6p1ccf8cjsn6cc84ce96869" },
        { "x-rapidapi-host", "yt-api.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                YoutubeProfileDto youtube = JsonConvert.DeserializeObject<YoutubeProfileDto>(body2);
                ViewBag.Subscribers = youtube.subscriberCountText;
                ViewBag.ViewCounts = youtube.viewCount;
            }
            return View();
        }

    }
}
