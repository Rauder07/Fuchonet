using Fuchonet.Dto.Request;
using Fuchonet.Dto.Response;
using Fuchonet.Entities.Models;

using Fuchonet.Repositories;
using Fuchonet.Services.Interface;
using Mapster;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuchonet.Repositories.Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Http;

namespace Fuchonet.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        public IUnitOfWork _unitOfWork;
        //private readonly IPagedList _pagination;
        public CustomerService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerDTO>> Get(PaginationParams request, string? query, string? loadRelations)
        {           

            /*
             OBTENER DATA
             */
            
            var customerList = await _unitOfWork.CustomerRepository.Get(loadRelations);
            var sessionsQuery = customerList.AsQueryable();

            /*
             FILTRAR DATA 
             */

            //se crea objeto con los parametros para el filtro
            var filterResult = new RootFilter();

            //validar que haya filtros
            if (!string.IsNullOrEmpty(query))
            {
                //deserializa el query en RootFilter
                filterResult = JsonConvert.DeserializeObject<RootFilter>(query);    
            }
            else
            {
                filterResult = new RootFilter();
            }          

            //Aplicar filtros
            if (filterResult.Filters != null)
            {
                sessionsQuery = CompositeFilter<Customer>.ApplyFilter(sessionsQuery, filterResult);
            }

            /*
             MAPEAR DATA
             */
            
            //var sessionsQueryDTO = sessionsQuery.ProjectToType<CustomerDTO>();
            var sessionsQueryDTO = sessionsQuery.Adapt<List<CustomerDTO>>();
            
            return sessionsQueryDTO;
        }

        public async Task<CustomerDTO> GetById(int id, string? loadRelations)
        {
            var customer = await _unitOfWork.CustomerRepository.GetById(id, loadRelations);
            var sessionQueryDTO = customer.Adapt<CustomerDTO>();
            return sessionQueryDTO;
        }
    }
}

