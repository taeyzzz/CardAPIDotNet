using System;
using Application.DTOs.User;

namespace Application.DTOs.Card
{
    public class CardDTO
    {
        public Guid Id { get; init; }
        
        public string Title { get; set; }

        public string Message { get; set; }

        public Guid AuthorId { get; set; }

        public UserDTO Author { get; set; }
    }
}