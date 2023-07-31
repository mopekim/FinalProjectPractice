namespace RouteMasterUpOne.Models.Dtos
{
	public class CommentsAccommodationsIndexDto
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string HotelName { get; set; }
		public int Score { get; set; }
		public string? Title { get; set; }
        public string? Pros { get; set; }
        public string? Cons { get; set; }
        public DateTime CreateDate { get; set; }
        //public IEnumerable<string>? Images { get; set; }

    }
}
