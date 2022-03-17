using System;
using DotNet5.Models.Filter;

namespace DotNet5.Services.Interfaces
{
    public interface IUriService
    {
         public Uri GetPageUri(PaginationFilter filter, string route);
    }
}