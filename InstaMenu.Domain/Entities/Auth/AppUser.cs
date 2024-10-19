using Microsoft.AspNetCore.Identity;

namespace InstaMenu.Domain.Entities.Auth
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }


        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
    }
}
