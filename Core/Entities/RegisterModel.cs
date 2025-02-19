﻿using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
