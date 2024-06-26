﻿using System.ComponentModel.DataAnnotations;

namespace REST.APIs.Models.DTOs
{
    public class RegisterUserRequestDto
    {

        [DataType(DataType.EmailAddress)]
        [Required]
        public required string Username { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public required string Password { get; set; }

        [Required]
        public required string[] Roles { get; set; }
    }
}
