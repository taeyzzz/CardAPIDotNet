using System;
using System.ComponentModel.DataAnnotations;

namespace CardApi.Model
{
    public class Card : BaseEntity
    {
        public Guid Id { get; init; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        public string Message { get; set; }

        public Guid AuthorId { get; set; }

        public User Author { get; set; }
    }
}
