using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User
{
    public class CreateUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }
        public string Lastname { get; set; }        
    }
}
