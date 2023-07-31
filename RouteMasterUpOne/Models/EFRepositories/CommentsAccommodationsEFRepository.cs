using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RouteMasterUpOne.Models.Dtos;
using RouteMasterUpOne.Models.Exts;
using RouteMasterUpOne.Models.Interfaces;

namespace RouteMasterUpOne.Models.EFRepositories
{
	public class CommentsAccommodationsEFRepository : ICommentsAccommodationsRepository
	{
		private readonly CoreRouteMasterContext _db= new CoreRouteMasterContext();
		public async Task<IEnumerable<CommentsAccommodationsIndexDto>> Search(CommentPostDTO input)
		{
            var commentDb = _db.CommentsAccommodations
                .Include(c => c.Member)
                .Include(c => c.Accommodation)
                .Where(c => c.AccommodationId == input.HotelId);
			   

           
            switch (input.Manner)
            {
                case 0:
                    commentDb = commentDb.OrderBy(c => c.Id);
                    break;
                case 1:
                    commentDb = commentDb.OrderByDescending(c => c.CreateDate);
                    break;
                case 2:
                    commentDb = commentDb.OrderByDescending(c => c.Score);
                    break;
                case 3:
                    commentDb = commentDb.OrderBy(c => c.Score);
                    break;
            }


            return await commentDb.AsNoTracking().Select(c => c.ToIndexDto()).ToListAsync();
				
				
				
		}
	}
}
