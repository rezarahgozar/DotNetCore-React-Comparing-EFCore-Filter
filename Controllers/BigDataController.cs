using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using DotNet5.Entity;
using DotNet5.Helpers;
using DotNet5.Models.Filter;
using DotNet5.Services.Interfaces;
using EmailModule.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailModule.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class BigDataController : Controller
    {


        private MyDbContext _dbContext;
        private readonly IUriService _uriService;
        public BigDataController(MyDbContext dbContext, IUriService uriService)
        {
            _dbContext = dbContext;
            _uriService = uriService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetListEntityWhereOut([FromQuery] BigDataFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new DotNet5
            .Models.Filter.
            PaginationFilter((filter.PaginationParameters == null) ? 1 : filter.PaginationParameters.PageNumber, (filter.PaginationParameters == null) ? 20 : filter.PaginationParameters.PageSize);

            IEnumerable<BigData> query = _dbContext.Set<BigData>()
            .Take(1000000)
            .AsNoTracking();

            if (!string.IsNullOrEmpty(filter.Col1))
            {
                query = query.Where(x => x.Col1 == filter.Col1);
            }
            if (!string.IsNullOrEmpty(filter.Col2))
            {
                query = query.Where(x => x.Col2 == filter.Col2);
            }
            if (!string.IsNullOrEmpty(filter.Col3))
            {
                query = query.Where(x => x.Col3 == filter.Col3);
            }
            if (!string.IsNullOrEmpty(filter.Col5))
            {
                query = query.Where(x => x.Col5 == float.Parse(filter.Col5));
            }
            if (!string.IsNullOrEmpty(filter.Col6))
            {
                query = query.Where(x => x.Col6 == Convert.ToInt32(filter.Col6));
            }
            DateTime col7Date;
            if (!string.IsNullOrEmpty(filter.Col7))
            {
                if (DateTime.TryParse(filter.Col7, out col7Date))
                {
                    col7Date = col7Date.Date;
                    query = query.Where(x => Convert.ToDateTime(x.Col7).Date == col7Date);
                }
            }
            if (!string.IsNullOrEmpty(filter.Col8))
            {
                query = query.Where(x => x.Col8 == float.Parse(filter.Col8));
            }
            DateTime col9Date;
            if (!string.IsNullOrEmpty(filter.Col9))
            {
                if (DateTime.TryParse(filter.Col9, out col9Date))
                {
                    col9Date = col9Date.Date;
                    query = query.Where(x => Convert.ToDateTime(x.Col9).Date == col9Date);
                }
            }
            if (!string.IsNullOrEmpty(filter.Col10))
            {
                query = query.Where(x => x.Col10 == filter.Col10);
            }


            if (filter.SortParameters != null && !string.IsNullOrEmpty(filter.SortParameters.Field) && !string.IsNullOrEmpty(filter.SortParameters.Field))
            {
                query = query.AsQueryable().OrderBy($"{filter.SortParameters.Field} {filter.SortParameters.Sort}");
            }
            else
            {
                query = query.OrderByDescending(x => x.Id);
            }

            var totalRecords = query.Count();

            query = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).ToList();
            query = query.Take(validFilter.PageSize).ToList();

            var pagedReponse = PaginationHelper.CreatePagedReponse<BigData>(query.ToList(), validFilter, totalRecords, _uriService, route);
            return Ok(pagedReponse);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetListEntityWhereIn([FromQuery] BigDataFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new DotNet5
            .Models.Filter.
            PaginationFilter((filter.PaginationParameters == null) ? 1 : filter.PaginationParameters.PageNumber, (filter.PaginationParameters == null) ? 20 : filter.PaginationParameters.PageSize);

            var query = await _dbContext.BigData
            .Take(1000000)
            .AsNoTracking()
            .Where(x => (string.IsNullOrEmpty(filter.Col1)) ? true : x.Col1 == filter.Col1)
            .Where(x => (string.IsNullOrEmpty(filter.Col2)) ? true : x.Col2 == filter.Col2)
            .Where(x => (string.IsNullOrEmpty(filter.Col3)) ? true : x.Col3 == filter.Col3)
            .Where(x => (string.IsNullOrEmpty(filter.Col5)) ? true : x.Col5 == float.Parse(filter.Col5))
            .Where(x => (string.IsNullOrEmpty(filter.Col6)) ? true : x.Col6 == Convert.ToInt32(filter.Col6))
            .Where(x => (string.IsNullOrEmpty(filter.Col7)) ? true : x.Col7 == Convert.ToDateTime(filter.Col7))
            .Where(x => (string.IsNullOrEmpty(filter.Col8)) ? true : x.Col8 == float.Parse(filter.Col8))
            .Where(x => (string.IsNullOrEmpty(filter.Col9)) ? true : x.Col9 == Convert.ToDateTime(filter.Col9))
            .Where(x => (string.IsNullOrEmpty(filter.Col10)) ? true : x.Col10 == filter.Col10)
            .OrderBy((filter.SortParameters != null && !string.IsNullOrEmpty(filter.SortParameters.Field) && !string.IsNullOrEmpty(filter.SortParameters.Field))
            ? $"{filter.SortParameters.Field} {filter.SortParameters.Sort}"
            : "Id DESC") // ASC
            .ToListAsync();

            var totalRecords = query.Count();

            query = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).ToList();
            query = query.Take(validFilter.PageSize).ToList();

            var pagedReponse = PaginationHelper.CreatePagedReponse<BigData>(query.ToList(), validFilter, totalRecords, _uriService, route);
            return Ok(pagedReponse);
        }

        // [HttpGet]
        // [Route("[action]/{id}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        //     var record = await _dbContext
        //     .BigData
        //     .Where(x => x.Id == id)
        //     .FirstOrDefaultAsync();
        //     return Ok(new DotNet5.Models.Wrapper.Response<BigData>(record));
        // }

    }
}