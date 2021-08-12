using CardApi.DTOs.User;

namespace CardApi.DTOs.Card
{
    public static class CardExtension
    {
        public static CardDTO ToDTO(this Model.Card card)
        {
            return card == null ?
                null :
                new CardDTO()
                {
                    Id = card.Id,
                    Title = card.Title,
                    Message = card.Message,
                    AuthorId = card.AuthorId,
                    Author = card.Author.ToDTO()
                };
        }
    }
}