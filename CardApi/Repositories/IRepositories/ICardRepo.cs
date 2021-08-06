using System;
using System.Collections.Generic;
using CardApi.Model;

namespace CardApi.Repositories.IRepositories
{
    public interface ICardRepo
    {
        List<Card> ListCards();
        Card GetCardById(Guid guid);
        Card UpdateCardById(Guid guid, Card card);
        Card CreateCard(Card card);
        void DeleteCardById(Guid guid);
    }
}
