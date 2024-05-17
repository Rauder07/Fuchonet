//using Fuchonet.FuchonetAPI.Paginator;
using Fuchonet.Dto.Request;
using Fuchonet.Dto.Response;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Fuchonet.Repositories.Utils
{
    public static class HttpContextExtension
    {
        public async static Task InsertarPaginationHeader<T>(this HttpContext context, IQueryable<T> queryable, PaginationParams paginationParams)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            //TODO: INSERTAR META DATOS DE PAGINACION
            int totalNumberOfRecords = queryable.Count();
            var totalPageCount = (int)Math.Ceiling((double)totalNumberOfRecords / paginationParams.PageSize);


            var PaginationMetaData = new PaginationMedaDataDTO
            {
                CurrentPage = paginationParams.PageNumber, //numero de pagina
                PageSize = paginationParams.PageSize, //cantidad de registros
                TotalNumberOfPages = totalPageCount, //numero total de paginas
                TotalNumberOfRecords = totalNumberOfRecords, //numero total de registros
                //hasNext
                //hasPrevious

            };
            context.Response.Headers.Add("Y-Pagination", JsonConvert.SerializeObject(PaginationMetaData));
        }




    }
}
