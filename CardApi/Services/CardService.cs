using System;
using System.Collections.Generic;
using CardApi.DTOs.Card;
using CardApi.Model;
using CardApi.Repositories.IRepositories;
using CardApi.Services.IServices;

namespace CardApi.Services
{
    public class CardService : ICardService
    {
        private ICardRepo _cardRepo;
        public CardService(ICardRepo cardRepo)
        {
            _cardRepo = cardRepo;
        }

        public Card CreateCard(CreateCardDTO card)
        {
            var newModel = new Card
            {
                Title = card.Title,
                Message = card.Message,
                AuthorId = card.AuthorId
            };
            return _cardRepo.CreateCard(newModel);
        }

        public void DeleteCardById(Guid guid)
        {
            _cardRepo.DeleteCardById(guid);
        }

        public Card GetCardById(Guid guid)
        {
            return _cardRepo.GetCardById(guid);
        }

        public List<Card> ListCards()
        {
            return _cardRepo.ListCards();
        }

        public Card UpdateCardById(Guid guid, UpdateCardDTO card)
        {
            var newModel = new Card
            {
                Title = card.Title,
                Message = card.Message
            };
            return _cardRepo.UpdateCardById(guid, newModel);
        }
    }
}
