using MovieLandAPI.DTOs;

namespace MovieLandAPI.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
        {
            return queryable
                .Skip((paginationDTO.Page - 1) * paginationDTO.NumberOfRecordsPerPage)
                .Take(paginationDTO.NumberOfRecordsPerPage);
        }
    }
}
