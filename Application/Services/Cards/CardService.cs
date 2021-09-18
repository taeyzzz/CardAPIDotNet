using System;
using System.Collections.Generic;
using Application.DTOs.Card;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services.Cards
{
    public class CardService : ICardService
    {
        private ICardRepository _cardRepo;
        public CardService(ICardRepository cardRepo)
        {
            _cardRepo = cardRepo;
        }

        public Card CreateCard(CreateCardDTO card, Guid authorId)
        {
            var newModel = new Card
            {
                Title = card.Title,
                Message = card.Message,
                AuthorId = authorId
            };
            return _cardRepo.CreateCard(newModel);
        }

        public void DeleteCardById(Guid guid, Guid authorId)
        {
            if (!IsUserHasPermission(guid, authorId))
            {
                throw new ForbiddenException();
            }
            _cardRepo.DeleteCardById(guid);
        }

        public Card GetCardById(Guid guid, Guid authorId)
        {
            if (!IsUserHasPermission(guid, authorId))
            {
                throw new ForbiddenException();
            }
            return _cardRepo.GetCardById(guid);
        }

        public List<Card> ListCards()
        {
            return _cardRepo.ListCards();
        }

        public Card UpdateCardById(Guid guid, UpdateCardDTO card, Guid authorId)
        {
            if (!IsUserHasPermission(guid, authorId))
            {
                throw new ForbiddenException();
            }
            var newModel = new Card
            {
                Title = card.Title,
                Message = card.Message
            };
            return _cardRepo.UpdateCardById(guid, newModel);
        }

        private bool IsUserHasPermission(Guid cardId, Guid authorId)
        {
            var targetCard = _cardRepo.GetCardById(cardId);
            if (targetCard.AuthorId != authorId)
            {
                return false;
            }
            return true;
        }
    }
}
