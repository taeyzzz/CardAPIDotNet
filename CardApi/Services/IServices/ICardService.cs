using System;
using System.Collections.Generic;
using CardApi.DTOs.Card;
using CardApi.Model;

namespace CardApi.Services.IServices
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
