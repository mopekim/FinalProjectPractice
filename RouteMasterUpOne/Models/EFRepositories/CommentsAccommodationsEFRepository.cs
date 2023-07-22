using Microsoft.EntityFrameworkCore;
using RouteMasterUpOne.Models.Dtos;
using RouteMasterUpOne.Models.Exts;
using RouteMasterUpOne.Models.Interfaces;

namespace RouteMasterUpOne.Models.EFRepositories
{
	public class CommentsAccommodationsEFRepository : ICommentsAccommodationsRepository
	{
		private readonly CoreRouteMasterContext _db= new CoreRouteMasterContext();
		public async Task<IEnumerable<CommentsAccommodationsIndexDto>> Search()
		{
			var commentDb = _db.CommentsAccommodations
				.Include(c => c.Member)
				.Include(c => c.Accommodation)
				.AsNoTracking()
				.Select(c => c.ToIndexDto());

			return await commentDb.ToListAsync();
				
				
				
		}
	}
}
