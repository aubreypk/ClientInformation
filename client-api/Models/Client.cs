using System;
using System.Collections.Generic;

namespace client_api.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string Surname { get; set; }
        public string Names { get; set; }
        
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Phone> PhoneNumbers { get; set; }
    }
}