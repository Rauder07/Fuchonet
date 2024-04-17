using FuchonetAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FuchonetAPI.Paginator
{
    public class PagedList : IPagedList
    {
        public async Task<PagedResult<T>> CreatedPageGenericResult<T>(IQueryable<T> queryable, int page, int pageSize, string ordeBy, bool ascending)
        {
            var totalNumberOfRecords = await queryable.CountAsync();
            var totalPageCount = (int)Math.Ceiling((double)totalNumberOfRecords / pageSize);
            var skipAmount = pageSize * (page - 1); //cantidad de registro a skipear segun la pagina
            var msg = string.Empty;
            var results = new List<T>();
           
            
            if(ordeBy == null)
            {
                results = await queryable.Skip(skipAmount).Take(pageSize).ToListAsync();
            }
            else
            {
                results = await queryable.OrderByPropertyOrField(ordeBy, ascending).Skip(skipAmount).Take(pageSize).ToListAsync();
                
            }

            

            return new PagedResult<T>
            {
                Results = results, //data
                CurrentPage = page, //numero de pagina
                PageSize = pageSize, //cantidad de registros
                TotalNumberOfPages = totalPageCount, //numero total de paginas
                TotalNumberOfRecords = totalNumberOfRecords, //numero total de registros
                
                //CurrentPage
                //hasNextPage
                //hasPreviousPage
            };
        }

    }
}
