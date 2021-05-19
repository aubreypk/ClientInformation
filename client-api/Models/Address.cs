namespace client_api.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
    }
}