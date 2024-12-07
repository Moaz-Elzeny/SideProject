using InstaMenu.Domain.Entities.Auth;

namespace InstaMenu.Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string PhoneNumber { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string AddressLink { get; set; }
        public string AddressAsText { get; set; }
        public string Logo { get; set; }
        public float MinimumOrder { get; set; }
        public float DeliveryFeePerKilometer { get; set; }
        public DateTime CreatedAt { get; set; }
        public int VisitCount { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }
    }
}
