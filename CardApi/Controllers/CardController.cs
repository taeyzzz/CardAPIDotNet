using System;
using System.Collections.Generic;
using CardApi.DTOs.Card;
using CardApi.Model;
using CardApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CardApi.Controllers
{
    [Route("api/[controller]")]
    public class CardController : APIBaseController
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public IEnumerable<Card> HandleGetCards()
        {
            return _cardService.ListCards();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Card> HandleGetCard([FromRoute] Guid id)
        {
            var card = _cardService.GetCardById(id);
            if (card == null)
            {
                return NotFound();
            }
            return card;
        }

        [HttpPost]
        public Card HandleCreateCard([FromBody] CreateCardDTO data)
        {
            var createdCard = _cardService.CreateCard(data);
            return createdCard;
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Card> HandleUpdateCard([FromRoute] Guid id, [FromBody] UpdateCardDTO data)
        {
            var card = _cardService.GetCardById(id);
            if (card == null)
            {
                return NotFound();
            }
            var updatedCard = _cardService.UpdateCardById(id, data);
            return updatedCard;
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult HandleDeleteCard([FromRoute] Guid id)
        {
            var card = _cardService.GetCardById(id);
            if (card == null)
            {
                return NotFound();
            }
            _cardService.DeleteCardById(id);
            return NoContent();
        }
    }
}
