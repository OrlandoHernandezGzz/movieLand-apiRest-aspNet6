using Microsoft.EntityFrameworkCore;

namespace MovieLandAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertParametersPagination<T>(this HttpContext httpContext, 
            IQueryable<T> queryable, int maxRecordsPerPage)
        {
            double quantity = await queryable.CountAsync();
            double quantityPerPages = Math.Ceiling(quantity / maxRecordsPerPage);
            httpContext.Response.Headers.Add("QuantityPages", quantityPerPages.ToString());
        }
    }
}
