using RouteMasterUpOne.Models.Dtos;

namespace RouteMasterUpOne.Models.Interfaces
{
	public interface ICommentsAccommodationsRepository
	{
		Task<IEnumerable<CommentsAccommodationsIndexDto>> Search();
	}
}
		