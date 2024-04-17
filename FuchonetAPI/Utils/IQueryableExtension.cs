using FuchonetAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FuchonetAPI.Utils
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int page, int pageSize, string ordeBy, bool ascending)
        {


            var skipAmount = pageSize * (page - 1); //cantidad de registro a skipear segun la pagina

            IQueryable<T> results = Enumerable.Empty<T>().AsQueryable();


            if (ordeBy == null)
            {
                results = queryable.Skip(skipAmount).Take(pageSize).AsQueryable();
            }
            else
            {
                results = queryable.OrderByPropertyOrField(ordeBy, ascending).Skip(skipAmount).Take(pageSize).AsQueryable();

            }



            return results;

        }
    }
}
