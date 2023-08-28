using Organic_Shop_BackEnd.DTO;

namespace Organic_Shop_BackEnd.Auth
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(string userEmail, string userPassword);
        Task<string> CreateToken(string userEmail);
    }
}
