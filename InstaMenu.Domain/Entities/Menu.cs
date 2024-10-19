using InstaMenu.Domain.Entities.Auth;

namespace InstaMenu.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
