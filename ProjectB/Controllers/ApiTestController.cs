using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiTestController : Controller
    {
        private readonly ILogger<ApiTestController> _logger;
        private readonly HotelApiService _hotelApiService;
        public ApiTestController(ILogger<ApiTestController> logger, HotelApiService hotelApiService)
        {
            _logger = logger;
            _hotelApiService = hotelApiService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetByName")]
        //[Route("/InitialzieApiAsync")]
        public async Task<string> GetByNameAsync(string name)
        {
            return await _hotelApiService.GetByNameAsync(name);
        }
        [HttpGet("ListHotels")]
        public async Task<string> ListHotelsAsync(int destionationId, string checkIn, string checkOut, int adults1)
        {
            return await _hotelApiService.ListHotelsAsync(destionationId, checkIn, checkOut, adults1);
        }
        [HttpGet("HotelDetails")]
        public async Task<string> HotelDetailsAsync(int hotelId)
        {
            return await _hotelApiService.HotelDetailsAsync(hotelId);
        }
    }
}
