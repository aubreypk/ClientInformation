using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using client_api.Models;
using System.Data;

namespace client_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            List<Client> clients = new List<Client>();
            var query = "SELECT * FROM Client";
            var args = new Dictionary<string, object>{};
            DataTable dt = client_api.DBAccess.ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                clients.Add(new Client
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Surname = Convert.ToString(dt.Rows[0]["Surname"]),
                    Names = Convert.ToString(dt.Rows[0]["Names"]),
                    Email = Convert.ToString(dt.Rows[0]["Email"]),
                });
            }

            return clients;
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return generateClient(id);
        }
        
        // Mock Data for testing
        public Client generateClient(int id)
        {
            return new Client
            {
                Id = id,
                Surname = "Africa",
                Names = "Azania",
                Email = "a@b.c",
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
