using System;

namespace Winter.API.DTO.Input_Models
{
    public class UserIM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AspNetId { get; set; }
        public string Email { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
