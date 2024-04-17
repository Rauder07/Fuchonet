using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FuchonetAPI.DataAccess;
using FuchonetAPI.Models;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using NuGet.Protocol;
using FuchonetAPI.Dtos;
using AutoMapper;
using Humanizer;
using System.Text.Json.Serialization;
using FuchonetAPI.Paginator;
using AutoMapper.QueryableExtensions;
using System.Text.Json;
using FuchonetAPI.Utils;

namespace FuchonetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly FuchonetDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPagedList _pagination;

        public CustomersController(FuchonetDbContext context, IMapper mapper, IPagedList pagination)
        {
            _context = context;
            _mapper = mapper;
            _pagination = pagination;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IQueryable<CustomerToListDTO>> GetCustomers([FromQuery] PaginationParams request)
        {
            //dbset de Customer + Phones
            IQueryable<Customer> iqueryable = _context.Customers.Include(x => x.Phones).AsQueryable();
            //Paginar db iqueryable
            var customerPaginate2 = await iqueryable.Paginate(request.PageNumber, request.PageSize, request.OrderBy!, request.OrderAsc).ToListAsync();
           //Insertar Header de paginacion 
            await HttpContext.InsertarPaginationHeader(iqueryable, request);
            //Mapear a CustomerToListDTO y retornar
            var customerMapper =  _mapper.ProjectTo<CustomerToListDTO>(customerPaginate2.AsQueryable());

            return customerMapper;
            //return _mapper.Map<List<CustomerToListDTO>>(customerPaginate2);

        }

        [HttpGet]
        [Route("Customer")]
        public  async Task<List<CustomerToListDTO>> GetDATA([FromQuery] PaginationParams request)
        {
            IQueryable<Customer> iqueryable = _context.Customers.Include(x => x.Phones).AsQueryable();
            //var customerPaginado = await _pagination.CreatedPageGenericResult(_context.Customers.Include(x => x.Phones), request.PageNumber, request.PageSize, request.OrderBy!, request.OrderAsc);
            var customerPaginate2 =await iqueryable.Paginate(request.PageNumber,request.PageSize,request.OrderBy!, request.OrderAsc).ToListAsync();
            
            //var paginationMetaData = new
            //{
            //    TotalPages = customerPaginado.TotalNumberOfPages,
            //    TotalRecords = customerPaginado.TotalNumberOfRecords,
            //    PageSize = customerPaginado.PageSize,
            //    CurrentPage = customerPaginado.CurrentPage,
            //    HasNextPage = customerPaginado.HasNext,
            //    HasPreviousPage = customerPaginado.HasPrevious
            //};
            //Response.Headers.Add("X-PAGINATION", JsonSerializer.Serialize(paginationMetaData));
            await HttpContext.InsertarPaginationHeader(iqueryable, request);
            return _mapper.Map<List<CustomerToListDTO>>(customerPaginate2);

        }

        [HttpGet]
        [Route("List/FindByQueryUnique")]
        public async Task<ActionResult<PaginadorGenerico<CustomerToListDTO>>> GetQueryAfter(string? buscar,
                                                                                string? orden = "Id",
                                                                                string? tipo_orden = "asc",
                                                                                int pagina = 1,
                                                                                int registros_por_pagina = 20)
        {
            
           
            PaginadorGenerico<CustomerToListDTO> _PaginadorCustomers;
            
           
            IEnumerable<Customer> IECustomers = new Customer[] { };
            List<CustomerToListDTO> _customer = new List<CustomerToListDTO>();
            //FILTRADO DE DATOS LISTANDO TODO
            if (!string.IsNullOrEmpty(buscar))
            {
                foreach (var item in buscar.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    IECustomers = _context.Customers.Include(x => x.Phones).Where(x => x.FirstName != null && x.FirstName.Contains(item.ToUpper()) ? true :
                                                       x.LastName != null && x.LastName.Contains(item.ToUpper()) ? true :
                                                       x.Dni != null && x.Dni.Contains(item.ToUpper()) ? true : false);
                    

                }
            }
            else
            {
                IECustomers = _context.Customers.Include(x => x.Phones).Take(registros_por_pagina);
            }

           
            
            _customer = _mapper.Map<List<CustomerToListDTO>>(IECustomers);

           
            //ORDEN DE COLUMNAS 
            switch (orden)
            {
                case "Id":
                    if (tipo_orden.ToLower() == "asc")
                    {
                        IECustomers = IECustomers.OrderBy(x => x.Id);
                    }
                    else if (tipo_orden.ToLower().Contains("desc"))
                    {
                        IECustomers = IECustomers.OrderByDescending(x => x.Id);
                    }

                    break;
                case "FirstName":
                    if (tipo_orden.ToLower() == "asc")
                    {
                        IECustomers = IECustomers.OrderBy(x => x.FirstName);
                    }
                    else if (tipo_orden.ToLower().Contains("desc"))
                    {
                        IECustomers = IECustomers.OrderByDescending(x => x.FirstName);
                    }
                    break;
                case "LastName":
                    if (tipo_orden.ToLower() == "asc")
                    {
                        IECustomers = IECustomers.OrderBy(x => x.LastName);
                    }
                    else if (tipo_orden.ToLower().Contains("desc"))
                    {
                        IECustomers = IECustomers.OrderByDescending(x => x.LastName);
                    }
                    break;
                case "Dni":
                    if (tipo_orden.ToLower() == "asc")
                    {
                        IECustomers = IECustomers.OrderBy(x => x.Dni);
                    }
                    else if (tipo_orden.ToLower().Contains("desc"))
                    {
                        IECustomers = IECustomers.OrderByDescending(x => x.Dni);
                    }
                    break;
                default:
                    if (tipo_orden.ToLower() == "asc")
                    {
                        IECustomers = IECustomers.OrderBy(x => x.Id);
                    }
                    else if (tipo_orden.ToLower().Contains("desc"))
                    {
                        IECustomers = IECustomers.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            //PAGINACION
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            // Número total de registros de la tabla Customers
            _TotalRegistros = IECustomers.Count();
            // Obtenemos la 'página de registros' de la tabla Customers
            IECustomers = IECustomers.Skip((pagina - 1) * registros_por_pagina)
                                             .Take(registros_por_pagina);
            // Número total de páginas de la tabla Customers 38 en total
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);

            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorCustomers = new PaginadorGenerico<CustomerToListDTO>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaActual = buscar,
                OrdenActual = orden,
                TipoOrdenActual = tipo_orden,
                Resultado = _customer
            };

            
            return _PaginadorCustomers;


        }
        [HttpGet]
        [Route("List/GetDataURL")]
        public async Task<ActionResult<List<Customer>>> Get([FromQuery] Filter? filter)
        {
            var result = from ov in _context.Customers

                         where
                             (filter.FirstName == null || ov.FirstName.Contains(filter.FirstName))
                             &&
                             (filter.LastName == null || ov.LastName.Contains(filter.LastName))
                             &&
                             (filter.Dni == null || ov.Dni.Contains(filter.Dni))
                             &&
                             ov.IsActive == true
                         select
                             ov;


            return result.ToList();
        }

            //GET: api/Customers/ Name =?
            [HttpGet]
        [Route("List/{Name}")]
        public async Task<ActionResult<List<Customer>>> GetCustomerByName(string Name)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            else
            {
                var customers = _context.Customers.Where(x => x.FirstName == Name);
                //var rpt = from customer in _context.Customers where customer.FirstName == Name select customer;
                
                return Ok(customers);
            }   

        }
        //GET: api/Customers/ Name =?
        [HttpGet]
        [Route("List/GetCustomerByLastName/")]
        public async Task<ActionResult<List<Customer>>> GetCustomerByLastName(string? FirstName,string? LastName)
        {
            
            if (_context.Customers == null)
            {
                return NotFound();
            }
            else
            {
                IQueryable<Customer> customers = null;


                //var rpt = from x in _context.Customers.Where(x => x.FirstName.IndexOf(FirstName) > -1) select x;

                // customers = from x in _context.Customers.Where(x => x.FirstName.Contains(FirstName), x.LastName.Contains(LastName)) select x;

                if (FirstName == null && LastName == null)
                {
                    return await _context.Customers.ToListAsync();
                }
                else if (FirstName == null)
                {
                    customers = from x in _context.Customers.Where(x => x.LastName.Contains(LastName)) select x;
                }
                else if (LastName == null)
                {
                    customers = from x in _context.Customers.Where(x => x.FirstName.Contains(FirstName)) select x;
                }
                else
                {
                    customers = from x in _context.Customers.Where(x => x.LastName.Contains(LastName) && x.FirstName.Contains(LastName)) select x;
                }



                return Ok(customers);
            }

        }
        //GET: api/Customers/ Name =?
        [HttpGet]
        [Route("List/GetDataCustomer/")]
        public async Task<ActionResult<List<Customer>>> GetDataCustomer([FromQuery]string? FirstName = "", string? LastName = "", string? Dni = "")
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            else
            {
                IQueryable<Customer> customers = null;

                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                {
                    customers = from x in _context.Customers select x;
                }else if (string.IsNullOrEmpty(LastName))
                {
                    customers = from x in _context.Customers
                                where x.FirstName.Contains(FirstName)
                                select x;
                }else if (string.IsNullOrEmpty(FirstName))
                {
                    customers = from x in _context.Customers
                                where x.LastName.Contains(LastName)
                                select x;
                }
                else
                {
                    customers = from x in _context.Customers
                                where x.FirstName.Contains(FirstName) && x.LastName.Contains(LastName)
                                select x;
                }

                
                


                return Ok(customers);
            }

        }
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerToListDTO>> GetCustomer(int id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }

            var customer = await _context.Customers.Include(x => x.Phones).Where(z=>z.Id==id).FirstOrDefaultAsync();
            var customerDTO = _mapper.Map<CustomerToListDTO>(customer);
            

            if (customerDTO == null)
            {
                return NotFound();
            }

            return customerDTO;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'FuchonetDbContext.Customers'  is null.");
          }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
