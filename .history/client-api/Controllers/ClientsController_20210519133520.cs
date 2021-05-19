using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using client_api.Models;

namespace client_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return new Client
            {
                Id = id,
                Surname = "Africa",
                Names = "Azania",
                IsActive = true,
                PhoneNumbers = new List<Phone>()
                {
                    new Phone
                    {
                        Id = 1,
                        Type = "Cell Phone",
                        Number = "0712345678"
                    },
                    new Phone
                    {
                        Id = 2,
                        Type = "Home Phone",
                        Number = "0123456789"
                    }
                },
                Addresses = new List<Address>()
                {
                    new Address
                    {
                        Id = 1,
                        Type = "Physical Address",
                        Line1 = "1 First Road",
                        Line2 = "Banana",
                        City = "Pretoria",
                        Country = "South Africa",
                        Code = "0001"
                    }
                }
            };
        }
    }
}
