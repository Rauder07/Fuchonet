using FuchonetAPI.Extensions;
using FuchonetAPI.Paginator;
using FuchonetAPI.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Linq;

namespace FuchonetAPI.Utils
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
            var totalNumberOfRecords = await queryable.CountAsync();
            var totalPageCount = (int)Math.Ceiling((double)totalNumberOfRecords / paginationParams.PageSize);


            var PaginationMetaData = new PagedDTO()
            {
                CurrentPage = paginationParams.PageNumber, //numero de pagina
                PageSize = paginationParams.PageSize, //cantidad de registros
                TotalNumberOfPages = totalPageCount, //numero total de paginas
                TotalNumberOfRecords = totalNumberOfRecords, //numero total de registros

            };
            context.Response.Headers.Add("Y-Pagination", JsonConvert.SerializeObject(PaginationMetaData));
        }




    }
}
