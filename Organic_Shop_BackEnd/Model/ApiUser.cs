using Microsoft.AspNetCore.Identity;

namespace Organic_Shop_BackEnd.Model
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
