using System;
using System.ComponentModel.DataAnnotations;

namespace CardApi.DTOs.User
{
    public class UpdateUserDTO
    {
        [StringLength(100)]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
