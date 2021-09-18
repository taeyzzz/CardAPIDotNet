using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICardRepository
    {
        List<Card> ListCards();
        Card GetCardById(Guid guid);
        Card UpdateCardById(Guid guid, Card card);
        Card CreateCard(Card card);
        void DeleteCardById(Guid guid);
    }
}
