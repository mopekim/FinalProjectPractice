using RouteMasterUpOne.Models.Dtos;
using RouteMasterUpOne.Models.ViewModels;

namespace RouteMasterUpOne.Models.Exts
{
	public static class CommentsAccommodationsExts
	{
		public static CommentsAccommodationsIndexDto ToIndexDto(this CommentsAccommodation entity)
		{
			return new CommentsAccommodationsIndexDto
			{
				Id = entity.Id,
				Account = entity.Member.Account,
				HotelName = entity.Accommodation.Name,
				Score = entity.Score,
				Pros=entity.Pros,
				Cons=entity.Cons,
				Title = entity.Title,
				CreateDate = entity.CreateDate
			};

		}

		public static CommentsAccommodationsIndexVM ToIndexVM(this CommentsAccommodationsIndexDto dto)
		{
			return new CommentsAccommodationsIndexVM
			{
				Id = dto.Id,
				Account = dto.Account,
				HotelName = dto.HotelName,
				Score = dto.Score,
				Pros=dto.Pros,
				Cons=dto.Cons,
				Title = dto.Title,
				CreateDate = dto.CreateDate
			};

		}
	}
}
