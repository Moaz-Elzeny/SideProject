using InstaMenu.Domain.Entities.Auth;

namespace InstaMenu.Domain.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public byte OrderNumber { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
