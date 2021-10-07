using System;

namespace ShopRu.Domain.Customer
{
    public class Customer
    {
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string  Email { get; set; }
        public bool IsAffliate { get; set; }
        public bool IsEmployee { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
