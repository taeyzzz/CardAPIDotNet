using System;
using System.Collections.Generic;
using CardApi.DTOs.Card;
using CardApi.Model;

namespace CardApi.Services.IServices
{
    public interface ICardService
    {
        List<Card> ListCards();
        Card GetCardById(Guid guid);
        Card UpdateCardById(Guid guid, UpdateCardDTO card);
        Card CreateCard(CreateCardDTO card);
        void DeleteCardById(Guid guid);      
    }
}
