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
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Surname = Convert.ToString(dt.Rows[i]["Surname"]),
                    Names = Convert.ToString(dt.Rows[i]["Names"]),
                    Email = Convert.ToString(dt.Rows[i]["Email"]),
                    IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"])
                });
            }

            return clients;
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            var query = "SELECT * FROM Client WHERE Id = @id";
            var args = new Dictionary<string, object>
            {
                {"@id", id}
            };

            DataTable dt = client_api.DBAccess.ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            var client = new Client
            {
                Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                Surname = Convert.ToString(dt.Rows[0]["Surname"]),
                Names = Convert.ToString(dt.Rows[0]["Names"]),
                Email = Convert.ToString(dt.Rows[0]["Email"]),
                IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]),
                PhoneNumbers = getPhoneByClient(Convert.ToInt32(dt.Rows[0]["Id"])).ToArray()
            };

            return client;
        }
        // Sub Queries
        public IEnumerable<Phone> getPhoneByClient(int clientID)
        {
            List<Phone> phones = new List<Phone>();
            var query = "SELECT * FROM Phone WHERE ClientId = @clientID";
            var args = new Dictionary<string, object>
            {
                {"@clientID", clientID}
            };
            DataTable dt = client_api.DBAccess.ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                phones.Add(new Phone
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Type = Convert.ToString(dt.Rows[i]["Type"]),
                    Number = Convert.ToString(dt.Rows[i]["Number"])
                });
            }

            return phones;
        }
    }
}
