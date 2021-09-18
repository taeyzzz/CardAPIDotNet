using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Card
{
    public class CreateCardDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public string Message { get; set; }
    }
}
