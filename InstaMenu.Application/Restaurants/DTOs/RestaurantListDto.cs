namespace InstaMenu.Application.Restaurants.DTOs
{
    public class RestaurantListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string PhoneNumber { get; set; }
        public float MinimumOrder { get; set; }
        public float DeliveryFeePerKilometer { get; set; }
        public int VisitCount { get; set; }
    }
}
