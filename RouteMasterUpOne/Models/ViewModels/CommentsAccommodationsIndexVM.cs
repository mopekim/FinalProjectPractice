using System.ComponentModel.DataAnnotations;

namespace RouteMasterUpOne.Models.ViewModels
{
	public class CommentsAccommodationsIndexVM
	{
		public int Id { get; set; }

		[Display(Name = "用戶帳號")]
        public string Account { get; set; }

		[Display(Name = "住宿名稱")]
		public string HotelName { get; set; }

		[Display(Name = "分數")]
		public int Score { get; set; }

		[Display(Name = "評論標題")]
		public string? Title { get; set; }

		[Display(Name = "建立時間")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
		public DateTime CreateDate { get; set; }
	}
}
