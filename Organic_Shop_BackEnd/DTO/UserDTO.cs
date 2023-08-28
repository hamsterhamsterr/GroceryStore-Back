using System.ComponentModel.DataAnnotations;

namespace Organic_Shop_BackEnd.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }
    }

    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }
    }
}
