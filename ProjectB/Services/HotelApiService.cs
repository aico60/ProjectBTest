using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectB.Services
{
    public class HotelApiService
    {
        public async Task<string> GetByNameAsync(string name)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://hotels4.p.rapidapi.com/locations/search?query={name}"),
                Headers =
                {
                    { "x-rapidapi-host", "hotels4.p.rapidapi.com" },
                    { "x-rapidapi-key", "a11e34100bmsh90f9a183989fac3p19911fjsnf7136fbb574e" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject(body);
                return result.ToString();
            }
        }
        public async Task<string> ListHotelsAsync(int destionationId, string checkIn, string checkOut, int adults1)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://hotels4.p.rapidapi.com/properties/list?destinationId={destionationId}&pageNumber=1&pageSize=25&checkIn={checkIn}&checkOut={checkOut}&adults1={adults1}&sortOrder=PRICE&locale=en_US&currency=USD"),
                Headers =
                {
                    { "x-rapidapi-host", "hotels4.p.rapidapi.com" },
                    { "x-rapidapi-key", "a11e34100bmsh90f9a183989fac3p19911fjsnf7136fbb574e" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject(body);
                return result.ToString();
            }
        }
        public async Task<string> HotelDetailsAsync(int hotelId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://hotels4.p.rapidapi.com/properties/get-details?id={hotelId}&checkIn=2020-01-08&checkOut=2020-01-15&adults1=1&currency=USD&locale=en_US"),
                Headers =
                {
                    { "x-rapidapi-host", "hotels4.p.rapidapi.com" },
                    { "x-rapidapi-key", "a11e34100bmsh90f9a183989fac3p19911fjsnf7136fbb574e" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject(body);
                return result.ToString();
            }
        }
    }
}
