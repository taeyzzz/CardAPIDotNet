using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User
{
    public class UserDTO
    {
        public Guid Id { get; init; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
