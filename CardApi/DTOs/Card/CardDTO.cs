﻿using System;
using CardApi.DTOs.User;

namespace CardApi.DTOs.Card
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