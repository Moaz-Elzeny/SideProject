namespace InstaMenu.Domain.Entities.Auth
{
    public class Item : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsEnable { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
