using System;
using System.Collections.Generic;
using System.Linq;
using CardApi.Attributes;
using CardApi.DTOs.Card;
using CardApi.Model;
using CardApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardApi.Controllers
{   
    [Route("api/[controller]")]
    [EnsureAuthenticated]
    public class CardController : APIBaseController
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<CardDTO> HandleGetCards()
        {
            return _cardService.ListCards().Select(c => c.ToDTO());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CardDTO> HandleGetCard([FromRoute] Guid id)
        {
            var currentUser = GetContextUser();
            var card = _cardService.GetCardById(id, currentUser.Id);
            if (card == null)
            {
                return NotFound();
            }
            return card.ToDTO();
        }

        [HttpPost]
        public CardDTO HandleCreateCard([FromBody] CreateCardDTO data)
        {
            var currentUser = GetContextUser();
            var createdCard = _cardService.CreateCard(data, currentUser.Id);
            return createdCard.ToDTO();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<CardDTO> HandleUpdateCard([FromRoute] Guid id, [FromBody] UpdateCardDTO data)
        {
            var currentUser = GetContextUser();
            var updatedCard = _cardService.UpdateCardById(id, data, currentUser.Id);
            return updatedCard.ToDTO();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult HandleDeleteCard([FromRoute] Guid id)
        {
            var currentUser = GetContextUser();
            _cardService.DeleteCardById(id, currentUser.Id);
            return NoContent();
        }
    }
}
