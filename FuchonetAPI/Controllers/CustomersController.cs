using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
using FuchonetAPI.DataAccess;
using FuchonetAPI.Models;
=======
using Fuchonet.Repositories;
using Fuchonet.Entities.Models;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using NuGet.Protocol;
//using Fuchonet.FuchonetAPI.Dtos;
using Fuchonet.Dto;
using Humanizer;
using System.Text.Json.Serialization;
using Fuchonet.FuchonetAPI.Paginator;
using Fuchonet.Dto.Request;
using Fuchonet.Dto.Response;
using System.Text.Json;
using Fuchonet.FuchonetAPI.Utility;
using Fuchonet.Services.Interface;
using Fuchonet.Services.Implementation;
using Mapster;
using Microsoft.AspNetCore.OData.Query;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
>>>>>>> Stashed changes

namespace FuchonetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
<<<<<<< Updated upstream
        private readonly FuchonetDbContext _context;

        public CustomersController(FuchonetDbContext context)
        {
            _context = context;
=======
        ICustomerService _customerService { get; set; }


        //private readonly CustomerService customerService = new CustomerService(new CustomerRepository)

        public CustomersController(ICustomerService customerService /*, IPagedList pagination*/)
        {
            //_pagination = pagination;
            _customerService = customerService;
>>>>>>> Stashed changes
        }

        // GET: api/Customers
        [HttpGet]
<<<<<<< Updated upstream
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
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

            return customer;
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
=======
        public async Task<IEnumerable<CustomerDTO>> Get([FromQuery] PaginationParams request, string? query, string? loadRelations)
        {
            var customersList = await _customerService.Get(request, query, loadRelations);
            await HttpContext.InsertarPaginationHeader(customersList.AsQueryable(), request);
            var sessionsQueryPaginate = customersList.AsQueryable().Paginate(request.PageNumber,
                                                               request.PageSize,
                                                               request.OrderBy!,
                                                               request.OrderAsc);

            return sessionsQueryPaginate;
        }

        // GET: api/Customers
        [HttpGet("{id}")]
        public async Task<CustomerDTO> GetById(int id, string loadRelations)
        {
            var customer = await _customerService.GetById(id, loadRelations);
                       
            return customer;
        }

        //// PUT: api/Customers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomer(int id, Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Customers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        //{
        //    if (_context.Customers == null)
        //    {
        //        return Problem("Entity set 'FuchonetDbContext.Customers'  is null.");
        //    }
        //    _context.Customers.Add(customer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        //}

        //// DELETE: api/Customers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomer(int id)
        //{
        //    if (_context.Customers == null)
        //    {
        //        return NotFound();
        //    }
        //    var customer = await _context.Customers.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CustomerExists(int id)
        //{
        //    return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
>>>>>>> Stashed changes
    }
}
