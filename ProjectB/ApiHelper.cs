using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectB
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Add("x-rapidapi-host", "hotels4.p.rapidapi.com");
            ApiClient.DefaultRequestHeaders.Add("x-rapidapi-key", "a11e34100bmsh90f9a183989fac3p19911fjsnf7136fbb574e");
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
