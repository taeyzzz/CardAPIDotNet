using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<CardDTO> HandleGetCards()
        {
            return _cardService.ListCards().Select(c => c.ToDTO());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CardDTO> HandleGetCard([FromRoute] Guid id)
        {
            var card = _cardService.GetCardById(id);
            if (card == null)
            {
                return NotFound();
            }
            return card.ToDTO();
        }

        [HttpPost]
        public CardDTO HandleCreateCard([FromBody] CreateCardDTO data)
        {
            var createdCard = _cardService.CreateCard(data);
            return createdCard.ToDTO();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<CardDTO> HandleUpdateCard([FromRoute] Guid id, [FromBody] UpdateCardDTO data)
        {
            var card = _cardService.GetCardById(id);
            if (card == null)
            {
                return NotFound();
            }
            var updatedCard = _cardService.UpdateCardById(id, data);
            return updatedCard.ToDTO();
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
