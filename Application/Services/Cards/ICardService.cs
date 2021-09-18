using System;
using System.Collections.Generic;
using Application.DTOs.Card;
using Domain.Entities;

namespace Application.Services.Cards
{
    public interface ICardService
    {
        List<Card> ListCards();
        Card GetCardById(Guid guid, Guid authorId);
        Card UpdateCardById(Guid guid, UpdateCardDTO card, Guid authorId);
        Card CreateCard(CreateCardDTO card, Guid authorId);
        void DeleteCardById(Guid guid, Guid authorId);      
    }
}
