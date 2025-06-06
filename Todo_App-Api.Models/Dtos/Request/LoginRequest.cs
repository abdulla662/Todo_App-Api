﻿using System.ComponentModel.DataAnnotations;

namespace Todo_App_Api.DTOs.Request
{
    public class LoginRequest
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
