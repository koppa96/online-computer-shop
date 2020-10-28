using System;

namespace OnlineComputerShop.Dal.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
        public int? Rating { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}