using System;
using System.Collections.Generic;
using System.Linq;
using CardApi.DBContext;
using CardApi.Middlewares.Error.Exceptions;
using CardApi.Model;
using CardApi.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CardApi.Repositories
{
    public class CardRepository : ICardRepo    
    {
        private AppDBContext _appDBContext;
        public CardRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Card CreateCard(Card card)
        {
            var result = _appDBContext.Cards.Add(card);
            _appDBContext.SaveChanges();
            return result.Entity;
        }

        public void DeleteCardById(Guid guid)
        {
            var targetCard = GetCardById(guid);
            _appDBContext.Cards.Remove(targetCard);
            _appDBContext.SaveChanges();
        }

        public Card GetCardById(Guid id)
        {
            var targetCard = _appDBContext.Cards.Find(id);
            if (targetCard == null)
            {
                throw new NotFoundException($"id {id} not found");
            }
            return targetCard;
        }

        public List<Card> ListCards()
        {
            return _appDBContext.Cards
                .Include(c => c.Author)
                .ToList();
        }

        public Card UpdateCardById(Guid guid, Card card)
        {
            var targetCard = GetCardById(guid);

            targetCard.Title = card.Title ?? targetCard.Title;
            targetCard.Message = card.Message ?? targetCard.Message;

            var updateUser = _appDBContext.Cards.Update(targetCard);
            _appDBContext.SaveChanges();
            return updateUser.Entity;
        }
    }
}
