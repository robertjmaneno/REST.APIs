using System.ComponentModel.DataAnnotations;

namespace REST.APIs.Models.DTOs
{
    public class LoginUserRequestDto
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public required string Username { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public required string Password { get; set; }
    }
}
