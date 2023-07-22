using RouteMasterUpOne.Models.Dtos;
using RouteMasterUpOne.Models.Interfaces;
using RouteMasterUpOne.Models.SupportUnits;

namespace RouteMasterUpOne.Models.Services
{
	public class CommentsAccommodationsService
	{
		private ICommentsAccommodationsRepository _repo;
		
		public CommentsAccommodationsService(ICommentsAccommodationsRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<CommentsAccommodationsIndexDto>> Search()
		{
			return await _repo.Search();
		}
	}
}
