using System;
using System.Collections.Generic;
using System.Linq;
using CardApi.DBContext;
using CardApi.Model;
using CardApi.Repositories.IRepositories;

namespace CardApi.Repositories
{
    public class CardRepository : ICardRepo    
    {
        private AppDBContext _appDBContext;
        private List<Card> _cards;
        public CardRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            _cards = new List<Card>();
        }

        public Card CreateCard(Card card)
        {
            var createdCard = new Card
            {
                //Id = Guid.NewGuid(),
                Title = card.Title,
                Message = card.Message,
                AuthorId = card.AuthorId
            };
            var result = _appDBContext.DBCard.Add(createdCard);
            _appDBContext.SaveChanges();
            //_cards.Add(createdCard);
            return result.Entity;
        }

        public void DeleteCardById(Guid guid)
        {
            _cards = _cards.Where(c => c.Id != guid).ToList();
        }

        public Card GetCardById(Guid guid)
        {
            return _cards.Find(c => c.Id == guid);
        }

        public List<Card> ListCards()
        {
            return _cards;
        }

        public Card UpdateCardById(Guid guid, Card card)
        {
            _cards = _cards.Select(c => c.Id == guid ? UpdateCard(c, card) : c).ToList();
            var targetCard = _cards.Find(c => c.Id == guid);
            return targetCard;
        }

        private Card UpdateCard(Card oldCard, Card card)
        {
            return new Card
            {
                Id = oldCard.Id,
                Title = card.Title ?? oldCard.Title,
                Message = card.Title ?? oldCard.Title,
                AuthorId = oldCard.AuthorId
            };
        }
    }
}
