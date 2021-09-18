using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Card
{
    public class CardRepository : ICardRepository
    {
        private AppDBContext _appDBContext;
        public CardRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Domain.Entities.Card CreateCard(Domain.Entities.Card card)
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

        public Domain.Entities.Card GetCardById(Guid id)
        {
            var targetCard = _appDBContext.Cards.Find(id);
            if (targetCard == null)
            {
                throw new NotFoundException($"id {id} not found");
            }
            return targetCard;
        }

        public List<Domain.Entities.Card> ListCards()
        {
            return _appDBContext.Cards
                .Include(c => c.Author)
                .ToList();
        }

        public Domain.Entities.Card UpdateCardById(Guid guid, Domain.Entities.Card card)
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
