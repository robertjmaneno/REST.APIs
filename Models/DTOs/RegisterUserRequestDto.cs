using System.ComponentModel.DataAnnotations;

namespace REST.APIs.Models.DTOs
{
    public class RegisterUserRequestDto
    {

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Username { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        public string[] Roles { get; set; }
    }
}
