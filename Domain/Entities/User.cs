using System;
using System.ComponentModel.DataAnnotations;
using Domain.Commons;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid Id { get; init; }

        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
